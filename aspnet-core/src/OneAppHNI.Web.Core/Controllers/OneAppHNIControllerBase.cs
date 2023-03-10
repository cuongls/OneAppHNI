using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OneAppHNI.Controllers
{
    public abstract class OneAppHNIControllerBase: AbpController
    {
        protected OneAppHNIControllerBase()
        {
            LocalizationSourceName = OneAppHNIConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
