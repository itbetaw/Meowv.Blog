﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Meowv.Blog.Domain.Blog.Repositories
{
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}
