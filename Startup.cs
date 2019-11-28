using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ERPServer.Bussiness.JWTHelper;
using ERPServer.Bussiness.Privilege;
using ERPServer.DataAccess;
using ERPServer.DTO;
using ERPServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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
            options.UseSqlServer(Configuration.GetConnectionString(MigrationManager.CONNECTION_NAME).Replace("|DataDirectory|",
            System.IO.Directory.GetCurrentDirectory() + MigrationManager.DATABASE_PATH)));

            services.AddTransient<IPrivilegeService, EFPrivilegeService>();

            services.AddAutoMapper(typeof(PrivilegeAutoMapperProfileConfiguration));

            services.Configure<JWTSetting>(Configuration.GetSection("JWTSetting"));
            JWTSetting jwtSetting = new JWTSetting();
            Configuration.Bind("JWTSetting", jwtSetting);
            JWTHelper.Setting = jwtSetting;
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = true,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = jwtSetting.Audience,//Audience
                    ValidIssuer = jwtSetting.Issuer,//Issuer，这两项和前面签发jwt的设置一致
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey)),//拿到SecurityKey
                    //ClockSkew = TimeSpan.FromSeconds(3)//缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间，如果不配置，默认是5分钟
                };
            });
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

            app.UseAuthentication();

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
