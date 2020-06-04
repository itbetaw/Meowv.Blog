using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Meowv.Blog.Domain.Configurations
{
    public class AppSettings
    {
        private static readonly IConfigurationRoot _config;
        static AppSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            _config = builder.Build();
        }
        public static string EnableDb => _config["ConnectionStrings:Enable"];
        public static string ConnectionString => _config.GetConnectionString(EnableDb);
        /// <summary>
        /// ApiVersion
        /// </summary>
        public static string ApiVersion => _config["ApiVersion"];
    }
}
