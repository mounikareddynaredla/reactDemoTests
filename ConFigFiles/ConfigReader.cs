using Microsoft.Extensions.Configuration;


namespace ReactSpecFlowTests.ConFigFiles
{
    public static class ConfigReader
    {
        public static string GetConfiguration(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static string GetConfigurationFromJson(string key)
        {
            return new ConfigurationBuilder().AddJsonFile("app-config.json").Build()[key];
        }

    }
}
