using Meowv.Blog.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meowv.Blog.ToolKits.GitHub
{
    public class AuthorizeRequest
    {
        public string Client_ID = GitHubConfig.Client_ID;
        public string Redirect_Uri = GitHubConfig.Redirect_Uri;
        public string State { get; set; } = Guid.NewGuid().ToString("N");
        public string Scope { get; set; } = "user,public_repo";
    }
}
