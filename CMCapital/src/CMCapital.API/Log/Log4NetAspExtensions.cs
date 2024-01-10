using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace CMCapital.API
{
    public static class Log4NetAspExtensions
    {
        public static void ConfigureLog4Net(this IHostingEnvironment env, string configFile)
        {
            GlobalContext.Properties["webRoot"] = env.WebRootPath;
            XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));
        }

        public static void AddLog4Net(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new Log4NetProvider());
        }
    }
}