using Meowv.Blog.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meowv.Blog.Authorize
{
    public interface IAuthorizeService
    {
        Task<ServiceResult<string>> GetLoginAddressAsync();
        Task<ServiceResult<string>> GetAccessTokenAsync(string code);
        Task<ServiceResult<string>> GenerateTokenAsync(string access_token);
    }
}
