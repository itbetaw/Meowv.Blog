using log4net;
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
        private readonly ILog _log;

        public MeowvBlogExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(MeowvBlogExceptionFilter));
        }
        public void OnException(ExceptionContext context)
        {
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
