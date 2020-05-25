using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Meowv.Blog
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(MeowvBlogDomainSharedModule)
        )]
    public class MeowvBlogDomainModule : AbpModule
    {

    }
}
