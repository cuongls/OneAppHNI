using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OneAppHNI.Localization
{
    public static class OneAppHNILocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(OneAppHNIConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(OneAppHNILocalizationConfigurer).GetAssembly(),
                        "OneAppHNI.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
