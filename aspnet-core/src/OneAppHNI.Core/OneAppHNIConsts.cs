using OneAppHNI.Debugging;

namespace OneAppHNI
{
    public class OneAppHNIConsts
    {
        public const string LocalizationSourceName = "OneAppHNI";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f5900d2c59ba48ec80d300255981610e";
    }
}
