using System.Collections.Generic;
using Abp.Configuration;

namespace OneAppHNI.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()),
                new SettingDefinition(AppSettingNames.AcountEmailSend, "", scopes: SettingScopes.Application, clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()),
                new SettingDefinition(AppSettingNames.PassWordEmailSend, "", scopes: SettingScopes.Application, clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()),
                new SettingDefinition(AppSettingNames.EmailNhanCanhBaoDienNang, "", scopes: SettingScopes.Application, clientVisibilityProvider: new VisibleSettingClientVisibilityProvider()),
                new SettingDefinition(AppSettingNames.UrlXuatPhieuDHTT, "", scopes: SettingScopes.Application, clientVisibilityProvider: new VisibleSettingClientVisibilityProvider())
            };
        }
    }
}
