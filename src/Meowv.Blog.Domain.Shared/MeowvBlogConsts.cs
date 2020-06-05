﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Meowv.Blog.Domain.Shared
{
    public class MeowvBlogConsts
    {
        /// <summary>
        /// 数据库表前缀
        /// </summary>
        public const string DbTablePrefix = "meowv_";
    }
    /// <summary>
    /// 分组
    /// </summary>
    public static class Grouping
    {
        /// <summary>
        /// 博客前台接口组
        /// </summary>
        public const string GroupName_v1 = "v1";

        /// <summary>
        /// 博客后台接口组
        /// </summary>
        public const string GroupName_v2 = "v2";

        /// <summary>
        /// 其他通用接口组
        /// </summary>
        public const string GroupName_v3 = "v3";

        /// <summary>
        /// JWT授权接口组
        /// </summary>
        public const string GroupName_v4 = "v4";
    }
    /// <summary>
    /// 缓存过期时间策略
    /// </summary>
    public static class CacheStrategy
    {
        /// <summary>
        /// 一天过期24小时
        /// </summary>

        public const int ONE_DAY = 1440;

        /// <summary>
        /// 12小时过期
        /// </summary>

        public const int HALF_DAY = 720;

        /// <summary>
        /// 8小时过期
        /// </summary>

        public const int EIGHT_HOURS = 480;

        /// <summary>
        /// 5小时过期
        /// </summary>

        public const int FIVE_HOURS = 300;

        /// <summary>
        /// 3小时过期
        /// </summary>

        public const int THREE_HOURS = 180;

        /// <summary>
        /// 2小时过期
        /// </summary>

        public const int TWO_HOURS = 120;

        /// <summary>
        /// 1小时过期
        /// </summary>

        public const int ONE_HOURS = 60;

        /// <summary>
        /// 半小时过期
        /// </summary>

        public const int HALF_HOURS = 30;

        /// <summary>
        /// 5分钟过期
        /// </summary>
        public const int FIVE_MINUTES = 5;

        /// <summary>
        /// 1分钟过期
        /// </summary>
        public const int ONE_MINUTE = 1;

        /// <summary>
        /// 永不过期
        /// </summary>

        public const int NEVER = -1;
    }
}
