using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Models.Interfaces
{
    public interface IComment
    {
        string Content { get; set; }
        DateTime PostDate { get; set; }
        string UserName { get; set; }
        string UserEmail { get; set; }
        string UserWebsite { get; set; }
        bool Approved { get; set; }
    }
}
