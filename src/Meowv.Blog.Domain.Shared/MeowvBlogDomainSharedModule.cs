using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Meowv.Blog
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule)
        )]
    public class MeowvBlogDomainSharedModule : AbpModule
    {
    }
}
