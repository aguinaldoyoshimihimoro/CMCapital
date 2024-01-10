using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Data.SqlClient;
using System;

namespace CMCapital.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //try
            //{
            //    using (var conn = new SqlConnection("Server=10.0.140.19;Database=HUB_LIQUIDITY;User Id=cyrnel;Password=cyrnel;MultipleActiveResultSets=true"))
            //    {
            //        var select = "select TOP 1 [Content] from  [dbo].[LogProcessRequests]  where PortfolioName like '%mirae asset%'order by  [Id] desc";

            //        conn.Open();

            //        using (var cmd = new SqlCommand(select, conn))
            //        {
            //            var reader = cmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                using (var writer = new StreamWriter(@"C:\temp\log.txt"))
            //                {
            //                    writer.WriteLine(reader[0].ToString());
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

        }
    }
}
