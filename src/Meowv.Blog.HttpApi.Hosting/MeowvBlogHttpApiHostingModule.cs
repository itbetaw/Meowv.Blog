using Meowv.Blog.Domain.Configurations;
using Meowv.Blog.EntityFrameworkCore;
using Meowv.Blog.HttpApi.Hosting.Middleware;
using Meowv.Blog.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Meowv.Blog.HttpApi.Hosting
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(MeowvBlogHttpApiModule),
        typeof(MeowvBlogSwaggerModule),
        typeof(AbpAutofacModule),
       typeof(MeowvBlogFrameworkCoreModule)
        )]
    public class MeowvBlogHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.FromSeconds(30),
                        ValidAudience = AppSettings.JWT.Domain,
                        ValidIssuer = AppSettings.JWT.Domain,
                        IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                    };

                });
            //认证授权
            context.Services.AddAuthorization();
            //http请求
            context.Services.AddHttpClient();
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                //生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 使用路由
            app.UseRouting();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //身份验证
            app.UseAuthentication();

            //认证授权
            app.UseAuthorization();

            //异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
