using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.SqlServer;
using Meowv.Blog.Domain.Configurations;
using Meowv.Blog.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Meowv.Blog.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsModule))]
    public class MeowvBlogBackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(
                    new SqlServerStorage(AppSettings.ConnectionString,
                    new SqlServerStorageOptions
                    {
                        SchemaName = MeowvBlogConsts.DbTablePrefix + "hangfire"
                    }));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseHangfireServer();
            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[] {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions{
                        RequireSsl=false,
                        SslRedirect=false,
                        LoginCaseSensitive=true,
                        Users=new []{
                            new BasicAuthAuthorizationUser(){
                                Login=AppSettings.Hangfire.Login,
                                PasswordClear=AppSettings.Hangfire.Password
                            }
                        }

                    })
            },
                DashboardTitle = "任务调度中心"

            });
            var service = context.ServiceProvider;
            service.UseHangfireTest();
        }
    }
}
