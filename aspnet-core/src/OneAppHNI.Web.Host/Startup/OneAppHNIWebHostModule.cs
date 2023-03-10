using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OneAppHNI.Configuration;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;

namespace OneAppHNI.Web.Host.Startup
{
    [DependsOn(
       typeof(OneAppHNIWebCoreModule),
        typeof(AbpHangfireAspNetCoreModule)
        ) ]
    public class OneAppHNIWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OneAppHNIWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.UseHangfire();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OneAppHNIWebHostModule).GetAssembly());
        }
    }
}
