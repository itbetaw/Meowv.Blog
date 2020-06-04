using Meowv.Blog.ToolKits.Base.Paged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meowv.Blog.ToolKits.Base
{
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        public int Total { get; set; }
        public PagedList()
        {

        }
        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}
