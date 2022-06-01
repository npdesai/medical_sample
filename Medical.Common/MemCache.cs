using Medical.Common.Settings;
using Microsoft.Extensions.Configuration;

namespace Medical.Common
{
    public class MemCache
    {
        public static ConnectionStringsConfig ConnectionStrings { get; set; }
        public static LoginCredentialsConfig LoginCredentials { get; private set; }
        public static JwtSettingsConfig JwtSettings { get; private set; }
        public static CommonSettingsConfig CommonSettings { get; private set; }

        public static void SetConfiguration(IConfiguration configuration)
        {
            ConnectionStrings = new ConnectionStringsConfig();
            LoginCredentials = new LoginCredentialsConfig();
            JwtSettings = new JwtSettingsConfig();
            CommonSettings = new CommonSettingsConfig();

            if (configuration == null)
            {
                return;
            }

            foreach (var propertyInfo in typeof(ConnectionStringsConfig).GetProperties())
            {
                propertyInfo.SetValue(ConnectionStrings, configuration[$"ConnectionStrings:{propertyInfo.Name}"]);
            }

            foreach (var propertyInfo in typeof(LoginCredentialsConfig).GetProperties())
            {
                propertyInfo.SetValue(LoginCredentials, configuration[$"LoginCredentials:{propertyInfo.Name}"]);
            }

            foreach (var propertyInfo in typeof(JwtSettingsConfig).GetProperties())
            {
                propertyInfo.SetValue(JwtSettings, configuration[$"JwtSettings:{propertyInfo.Name}"]);
            }

            foreach (var propertyInfo in typeof(CommonSettingsConfig).GetProperties())
            {
                propertyInfo.SetValue(CommonSettings, configuration[$"CommonSettings:{propertyInfo.Name}"]);
            }
        }
    }
}
