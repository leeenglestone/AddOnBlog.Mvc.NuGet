using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Interfaces
{
    public interface IPost
    {
        string Id { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        List<IComment> Comments { get; set; }
    }
}
