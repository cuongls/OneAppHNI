using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OneAppHNI.EntityFrameworkCore;
using OneAppHNI.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OneAppHNI.Web.Tests
{
    [DependsOn(
        typeof(OneAppHNIWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class OneAppHNIWebTestModule : AbpModule
    {
        public OneAppHNIWebTestModule(OneAppHNIEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OneAppHNIWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(OneAppHNIWebMvcModule).Assembly);
        }
    }
}