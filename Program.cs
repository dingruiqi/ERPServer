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
                logger.Debug("init main");
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
                // .ConfigureLogging(logging =>//如果注释掉，则只使用nlog，不再显示系统终端的日志内容
                // {
                //     logging.ClearProviders();
                //     logging.AddConsole();
                //     //logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);//采用appsettings.json配置
                // })
                .UseNLog();  // NLog: Setup NLog for Dependency injection;
    }
}
