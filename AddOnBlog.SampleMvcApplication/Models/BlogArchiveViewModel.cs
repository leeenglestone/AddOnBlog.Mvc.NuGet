using AddOnBlog.Mvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddOnBlog.MvcApplication.Models
{
    public class BlogArchiveViewModel
    {
        public List<IPost> Posts { get; set; }
        public Dictionary<string, string> Archives { get; set; }

        public BlogArchiveViewModel()
        {
            Posts = new List<IPost>();
            Archives = new Dictionary<string, string>();
        }
    }
}