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
        string FriendlyUrl { get; set; }
        DateTime PostDate { get; set; }
        string Content { get; set; }
        string Categories { get; set; }
        string UserName { get; set; }
        string UserEmail { get; set; }
        string UserWebsite { get; set; }
        string SavePath { get; set; }
        bool Approved { get; set; }

        //IComments Comments { get; set; }
    }
}
