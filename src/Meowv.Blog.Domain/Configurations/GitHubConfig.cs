using Meowv.Blog.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meowv.Blog.Configurations
{
    public class GitHubConfig
    {
        /// <summary>
        /// GET请求，跳转GitHub登录界面，获取用户授权，得到Code
        /// </summary>
        public static string API_Authorize = "https://github.com/login/oauth/authorize";

        /// <summary>
        /// POST请求，根据Code得到access_token
        /// </summary>
        public static string API_AccessToken = "https://github.com/login/oauth/access_token";

        /// <summary>
        /// GET请求，根据access_token得到用户信息
        /// </summary>
        public static string API_User = "https://api.github.com/user";

        public static int UserId = AppSettings.Github.UserId;
        public static string Client_ID = AppSettings.Github.Client_ID;
        public static string Client_Secret = AppSettings.Github.Client_Secret;
        /// <summary>
        /// Authorization callback URL
        /// </summary>
        public static string Redirect_Uri = AppSettings.Github.Redirect_Uri;

        /// <summary>
        /// Application name
        /// </summary>
        public static string ApplicationName = AppSettings.Github.ApplicationName;
    }
}
