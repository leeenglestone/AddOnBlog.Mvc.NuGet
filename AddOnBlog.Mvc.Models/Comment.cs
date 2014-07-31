using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Models
{
    public class Comment
    {
        public DateTime PostDate { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserWebsite { get; set; }
        public bool Approved { get; set; }
        
    }
}
