using Microsoft.Extensions.Configuration;
using System.IO;

namespace CMCapital.Data
{
    public static class ConnectionString
    {
        private static string GetConnectionstring(string connectionName)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var provider = builder.Build();
            return provider.GetConnectionString(connectionName);
        }

        internal static string GetZEUSConnectionString()
        {
            return GetConnectionstring("ConnectionStringZEUS");
        }

        internal static string GetANBIDConnectionString()
        {
            return GetConnectionstring("ConnectionStringANBID");
        }

        public static string GetLiquidityConnectionString()
        {
            return GetConnectionstring("ConnectionStringHubLiquidity");
        }

        public static string GetHubDbConnectionString()
        {
            return GetConnectionstring("ConnectionStringHubDb");
        }
    }
}
