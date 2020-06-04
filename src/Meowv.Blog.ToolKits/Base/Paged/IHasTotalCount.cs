using System;
using System.Collections.Generic;
using System.Text;

namespace Meowv.Blog.ToolKits.Base.Paged
{
    public interface IHasTotalCount
    {
        int Total { get; set; }
    }
}
