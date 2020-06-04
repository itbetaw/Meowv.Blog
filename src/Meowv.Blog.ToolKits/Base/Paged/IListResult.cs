using System;
using System.Collections.Generic;
using System.Text;

namespace Meowv.Blog.ToolKits.Base.Paged
{
    public interface IListResult<T>
    {
        IReadOnlyList<T> Item { get; set; }
    }
}
