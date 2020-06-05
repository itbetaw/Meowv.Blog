using Meowv.Blog.ToolKits.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meowv.Blog.HttpApi.Hosting.Filters
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class MeowvBlogExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LoggerHelper.WriteToFile($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
