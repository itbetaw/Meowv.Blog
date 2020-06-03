﻿using Meowv.Blog.Domain.Blog;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Meowv.Blog.EntityFrameworkCore
{
    [ConnectionStringName("SqlServer")]
    public class MeowvBlogDbContext : AbpDbContext<MeowvBlogDbContext>
    {
        public MeowvBlogDbContext(DbContextOptions<MeowvBlogDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<FriendLink> FriendLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure();
        }
    }
}
