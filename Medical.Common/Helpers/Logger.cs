using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;

namespace Medical.Common.Helpers
{
    public static class Logger
    {
        private static string log4netConfigFilePath = MemCache.CommonSettings.Log4netConfigFilePath;
        private static ILog _log4net;

        private static void EnsureLogger()
        {
            if (_log4net != null) return;

            var assembly = Assembly.GetEntryAssembly();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var configFile = GetConfigFile();

            string fileName = assembly.ManifestModule.Name.Replace(".dll", "").Replace(".", " ");
            _log4net = log4net.LogManager.GetLogger(assembly, $"- {fileName}");
            log4net.GlobalContext.Properties["LogFileName"] = fileName;

            XmlConfigurator.Configure(logRepository, configFile);
        }

        private static FileInfo GetConfigFile()
        {
            FileInfo configFile = new(log4netConfigFilePath);

            if (configFile == null || !configFile.Exists) throw new NullReferenceException("log4net config file not found.");

            return configFile;
        }

        public static void Error(object input)
        {
            EnsureLogger();
            JObject objInput = JObject.FromObject(input);
            _log4net.Error(JsonConvert.SerializeObject(objInput, Formatting.Indented));
        }

        public static void Info(object input)
        {
            EnsureLogger();
            _log4net.Info(JsonConvert.SerializeObject(input, Formatting.Indented));
        }
    }
}
