using System;
using System.IO;
using ERPServer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ERPServer
{
    public static class MigrationManager
    {
        public const string DATABASE_PATH = "\\app_data\\database\\";
        public const string CONNECTION_NAME = "PrivilegeDatabase";
        public static IHost MigrateDatabase(this IHost host)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<PrivilegeManagementContext>())
                {
                    try
                    {
                        string path = System.IO.Directory.GetCurrentDirectory() + DATABASE_PATH;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        appContext.Database.Migrate();

                        logger.Info("migrate database successful");
                    }
                    catch (Exception e)
                    {
                        //Log errors or do anything you think it's needed
                        logger.Error(e, "migrate database because of exception");
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
