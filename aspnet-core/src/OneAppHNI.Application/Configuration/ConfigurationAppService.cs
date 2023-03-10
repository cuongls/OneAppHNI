using System;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using OneAppHNI.Configuration.Dto;

namespace OneAppHNI.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : OneAppHNIAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
        public async Task ChangeCauHinh(CauHinhDto input)
        {
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.AcountEmailSend, input.AcountEmailSend);
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.PassWordEmailSend, input.PassWordEmailSend);
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.EmailNhanCanhBaoDienNang, input.EmailNhanCanhBaoDienNang);
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.UrlXuatPhieuDHTT, input.UrlXuatPhieuDHTT);
        }
    }
}
