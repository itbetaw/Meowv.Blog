using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Meowv.Blog.EntityFrameworkCore
{

    [DependsOn(typeof(MeowvBlogFrameworkCoreModule))]
    public class MeowvBlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
