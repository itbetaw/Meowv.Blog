﻿using Meowv.Blog.Domain.Configurations;
using Meowv.Blog.Domain.Shared;
using Meowv.Blog.Swagger.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Meowv.Blog.Swagger
{
    public static class MeowvBlogSwaggerExtensions
    {
        /// <summary>
        /// 当前API版本，从appsettings.json获取
        /// </summary>
        private static readonly string version = $"v{AppSettings.ApiVersion}";

        /// <summary>
        /// Swagger描述信息
        /// </summary>
        private static readonly string description = @"<b>Blog</b>：<a target=""_blank"" href=""https://meowv.com"">https://meowv.com</a> <b>GitHub</b>：<a target=""_blank"" href=""https://github.com/wnxyz8023/Meowv.Blog"">https://github.com/wnxyz8023/Meowv.Blog</a> <b>Hangfire</b>：<a target=""_blank"" href=""/hangfire"">任务调度中心</a> <code>Powered by .NET Core 3.1 on Linux</code>";

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                //{

                //    Version = "1.0.0",
                //    Title = "我的接口",
                //    Description = "接口描述"
                //});
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Meowv.Blog.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Meowv.Blog.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Meowv.Blog.Application.Contracts.xml"));

                //应用Controller的 API文档描述信息
                options.DocumentFilter<SwaggerDocumentFilter>();

                #region 小绿锁 JWT验证

                var security = new OpenApiSecurityScheme()
                {
                    Description = "JWT模式授权,请输入Bearer {Token}进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("oauth2", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>
                ();
                options.OperationFilter<SecurityRequirementsOperationFilter>();


                #endregion

            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                //options.SwaggerEndpoint($"/swagger/v1/swagger.json", "默认接口");

                // 遍历分组信息，生成Json
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });
                options.DefaultModelsExpandDepth(-1);
                options.DocExpansion(DocExpansion.List);
                options.RoutePrefix = string.Empty;
                options.DocumentTitle = "😍接口文档----程序猿贝塔";

            });


        }

        internal class SwaggerApiInfo
        {
            public string UrlPrefix { get; set; }
            public string Name { get; set; }
            public OpenApiInfo OpenApiInfo { get; set; }
        }
        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>()
        {
            new SwaggerApiInfo()
            {
                UrlPrefix = Grouping.GroupName_v1,
                Name = "博客前台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "程序猿贝塔 - 博客前台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo()
            {
                UrlPrefix = Grouping.GroupName_v2,
                Name = "博客后台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "程序猿贝塔 - 博客后台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo()
            {
                UrlPrefix = Grouping.GroupName_v3,
                Name = "通用公共接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "程序猿贝塔 - 通用公共接口",
                    Description = description
                }
            },
            new SwaggerApiInfo()
            {
                UrlPrefix = Grouping.GroupName_v4,
                Name = "JWT授权接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "程序猿贝塔 - JWT授权接口",
                    Description = description
                }
            }

        };
    }
}
