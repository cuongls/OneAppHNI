using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OneAppHNI.Authorization;

namespace OneAppHNI
{
    [DependsOn(
        typeof(OneAppHNICoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OneAppHNIApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<OneAppHNIAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(OneAppHNIApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
