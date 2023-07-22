using log4net.Config;
using System.Reflection;
using System.Xml;

namespace TemplateNet6.WebApi.Configurations
{
    public static class LoggerConfiguration
    {
        public static void Configure()
        {
            XmlDocument log4netConfig = new();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repository = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            XmlConfigurator.Configure(repository, log4netConfig["configuration"]["log4net"]);
        }
    }
}
