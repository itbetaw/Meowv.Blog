﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Meowv.Blog.Domain.Blog.Repositories
{
    public interface IFriendLinkRepository : IRepository<FriendLink, int>
    {
    }
}
