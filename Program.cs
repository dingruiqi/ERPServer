using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace ERPServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            try
            {
                logger.Info("init main");
                CreateHostBuilder(args)
                .Build()
                .MigrateDatabase()//初始化数据库
                .Run();
            }
            catch (Exception exception)
            {
                //NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }

            // CreateHostBuilder(args)
            // .Build()
            // .MigrateDatabase()//初始化数据库
            // .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();//如果注释掉，则只显示nlog日志；否则，nlog的最小日志等级将被appsettings.json配置所覆盖。正式发布时，注释掉，只需要nlog
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);//注释掉，则采用appsettings.json配置
                })
                .UseNLog();  // NLog: Setup NLog for Dependency injection;
    }
}
