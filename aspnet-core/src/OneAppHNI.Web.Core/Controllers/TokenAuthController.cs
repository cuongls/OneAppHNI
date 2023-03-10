using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using Abp.UI;
using OneAppHNI.Authentication.External;
using OneAppHNI.Authentication.JwtBearer;
using OneAppHNI.Authorization;
using OneAppHNI.Authorization.Users;
using OneAppHNI.Models.TokenAuth;
using OneAppHNI.MultiTenancy;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using OneAppHNI.Users.Dto;
using OneAppHNI.Users;

namespace OneAppHNI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TokenAuthController : OneAppHNIControllerBase
    {
        private readonly LogInManager _logInManager;
        private readonly ITenantCache _tenantCache;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly TokenAuthConfiguration _configuration;
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        private readonly IExternalAuthManager _externalAuthManager;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly UserManager _userManager;
        private readonly TenantManager _tenantManager;

        public TokenAuthController(
            LogInManager logInManager,
            ITenantCache tenantCache,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            TokenAuthConfiguration configuration,
            IExternalAuthConfiguration externalAuthConfiguration,
            IExternalAuthManager externalAuthManager,
            UserRegistrationManager userRegistrationManager,
            UserManager userManager,
            TenantManager tenantManager)
        {
            _logInManager = logInManager;
            _tenantCache = tenantCache;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _configuration = configuration;
            _externalAuthConfiguration = externalAuthConfiguration;
            _externalAuthManager = externalAuthManager;
            _userRegistrationManager = userRegistrationManager;
            _userManager = userManager;
            _tenantManager = tenantManager;
        }

        [HttpPost]
        public async Task<AuthenticateResultModel> Authenticate([FromBody] AuthenticateModel model)
        {
            var loginResultVNPT = AuthCenterVNPT(model.UserNameOrEmailAddress, model.Password);
            if (loginResultVNPT != null)
            {
                if (loginResultVNPT.isError == false)
                {
                    var userExist = _userManager.FindByNameOrEmail(model.UserNameOrEmailAddress.ToLower());
                    if (userExist != null)
                    {
                        var loginResult = await GetLoginResultAsync(
                            model.UserNameOrEmailAddress.ToLower(),
                            "Cuongls@2020",
                            GetTenancyNameOrNull()
                        );

                        var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));

                        return new AuthenticateResultModel
                        {
                            AccessToken = accessToken,
                            EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                            UserId = loginResult.User.Id
                        };
                    }
                    else
                    {
                        var input = new CreateUserDto
                        {
                            EmailAddress = model.UserNameOrEmailAddress.ToLower() + "@vnpt.vn",
                            IsActive = true,
                            Name = model.UserNameOrEmailAddress.ToLower(),
                            Surname = model.UserNameOrEmailAddress.ToLower(),
                            Password = "Cuongls@2020",
                            UserName = model.UserNameOrEmailAddress.ToLower(),
                            RoleNames = new string[0],
                        };

                        var user = ObjectMapper.Map<User>(input);

                        if( _tenantManager.FindByTenancyName(GetTenancyNameOrNull()) != null)
                        {
                            user.TenantId = _tenantManager.FindByTenancyName(GetTenancyNameOrNull()).Id;
                        }
                        user.IsEmailConfirmed = true;

                        await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

                        CheckErrors(await _userManager.CreateAsync(user, input.Password));

                        if (input.RoleNames != null)
                        {
                            CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
                        }

                        CurrentUnitOfWork.SaveChanges();
                        
                        var loginResult = await GetLoginResultAsync(
                            model.UserNameOrEmailAddress.ToLower(),
                            "Cuongls@2020",
                            GetTenancyNameOrNull()
                        );

                        var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));

                        return new AuthenticateResultModel
                        {
                            AccessToken = accessToken,
                            EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                            UserId = loginResult.User.Id
                        };

                    }
                }
                else
                {
                    var loginResult = await GetLoginResultAsync(
                        model.UserNameOrEmailAddress,
                        model.Password,
                        GetTenancyNameOrNull()
                    );

                    var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));

                    return new AuthenticateResultModel
                    {
                        AccessToken = accessToken,
                        EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                        ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                        UserId = loginResult.User.Id
                    };
                }
            }
            else
            {
                var loginResult = await GetLoginResultAsync(
                model.UserNameOrEmailAddress,
                model.Password,
                GetTenancyNameOrNull()
            );

                var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));

                return new AuthenticateResultModel
                {
                    AccessToken = accessToken,
                    EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                    ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                    UserId = loginResult.User.Id
                };
            }    
        }

        [HttpGet]
        public List<ExternalLoginProviderInfoModel> GetExternalAuthenticationProviders()
        {
            return ObjectMapper.Map<List<ExternalLoginProviderInfoModel>>(_externalAuthConfiguration.Providers);
        }

        [HttpPost]
        public async Task<ExternalAuthenticateResultModel> ExternalAuthenticate([FromBody] ExternalAuthenticateModel model)
        {
            var externalUser = await GetExternalUserInfo(model);

            var loginResult = await _logInManager.LoginAsync(new UserLoginInfo(model.AuthProvider, model.ProviderKey, model.AuthProvider), GetTenancyNameOrNull());

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    {
                        var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));
                        return new ExternalAuthenticateResultModel
                        {
                            AccessToken = accessToken,
                            EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                        };
                    }
                case AbpLoginResultType.UnknownExternalLogin:
                    {
                        var newUser = await RegisterExternalUserAsync(externalUser);
                        if (!newUser.IsActive)
                        {
                            return new ExternalAuthenticateResultModel
                            {
                                WaitingForActivation = true
                            };
                        }

                        // Try to login again with newly registered user!
                        loginResult = await _logInManager.LoginAsync(new UserLoginInfo(model.AuthProvider, model.ProviderKey, model.AuthProvider), GetTenancyNameOrNull());
                        if (loginResult.Result != AbpLoginResultType.Success)
                        {
                            throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                                loginResult.Result,
                                model.ProviderKey,
                                GetTenancyNameOrNull()
                            );
                        }

                        var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));
                        
                        return new ExternalAuthenticateResultModel
                        {
                            AccessToken = accessToken,
                            EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                        };
                    }
                default:
                    {
                        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                            loginResult.Result,
                            model.ProviderKey,
                            GetTenancyNameOrNull()
                        );
                    }
            }
        }

        private async Task<User> RegisterExternalUserAsync(ExternalAuthUserInfo externalUser)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                externalUser.Name,
                externalUser.Surname,
                externalUser.EmailAddress,
                externalUser.EmailAddress,
                Authorization.Users.User.CreateRandomPassword(),
                true
            );

            user.Logins = new List<UserLogin>
            {
                new UserLogin
                {
                    LoginProvider = externalUser.Provider,
                    ProviderKey = externalUser.ProviderKey,
                    TenantId = user.TenantId
                }
            };

            await CurrentUnitOfWork.SaveChangesAsync();

            return user;
        }

        private async Task<ExternalAuthUserInfo> GetExternalUserInfo(ExternalAuthenticateModel model)
        {
            var userInfo = await _externalAuthManager.GetUserInfo(model.AuthProvider, model.ProviderAccessCode);
            if (userInfo.ProviderKey != model.ProviderKey)
            {
                throw new UserFriendlyException(L("CouldNotValidateExternalUser"));
            }

            return userInfo;
        }

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _configuration.Expiration),
                signingCredentials: _configuration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }

        private string GetEncryptedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken);
        }
        private class LoginResultDto
        {
            public bool isError { get; set; }
            public string Message { get; set; }
            public string Data { get; set; }
        }
        private LoginResultDto AuthCenterVNPT(String user, String password)
        {
            try
            {
                if (!user.Contains("@vnpt.vn"))
                    user = user + "@vnpt.vn";

                var request = (HttpWebRequest)WebRequest.Create("http://10.10.41.18/ApiAuthenVnpt/LdapVnpt/AuthenVnpt");
                NetworkCredential credentials = new NetworkCredential("WebApiUsername", "WebApiPattword");
                request.Credentials = credentials;
                var postData = "UserName=" + user;
                postData += "&PassWord=" + password;
                postData += "&AllowOtp=false";
                postData += "&SoDienThoaiFromVnpt=false";
                var data = Encoding.ASCII.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);

                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //"{\"IsError\":true,\"Message\":\"Người dùng duynv nhập sai mật khẩu \",\"Data\":null}"


                var XacThuResult = JsonConvert.DeserializeObject<LoginResultDto>(responseString);

                return XacThuResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
