using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPServer.Bussiness.Privilege;
using ERPServer.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ERPServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<PrivilegeManagementContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("PrivilegeDatabase").Replace("|DataDirectory|",
            System.IO.Directory.GetCurrentDirectory() + "\\app_data\\database\\")));

            services.AddTransient<IPrivilegeService, EFPrivilegeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, PrivilegeManagementContext context*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            // {
            //     var context = serviceScope.ServiceProvider.GetRequiredService<PrivilegeManagementContext>();
            //     context.Database.Migrate();
            // }
            //采用注入方式，更简单方便
            //context.Database.EnsureCreated();
            //现在有了更厉害的，在program中
        }
    }
}
