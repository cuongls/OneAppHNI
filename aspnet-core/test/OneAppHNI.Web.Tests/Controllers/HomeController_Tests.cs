using System.Threading.Tasks;
using OneAppHNI.Models.TokenAuth;
using OneAppHNI.Web.Controllers;
using Shouldly;
using Xunit;

namespace OneAppHNI.Web.Tests.Controllers
{
    public class HomeController_Tests: OneAppHNIWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}