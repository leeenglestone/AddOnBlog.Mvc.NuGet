using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Models;

namespace $rootnamespace$.MvcApplication.Models
{
    public class BlogViewModel
    {
        public List<IPost> Posts { get; set; }
        public Dictionary<string, string> Archives { get; set; }

        public BlogViewModel()
        {
            Posts = new List<IPost>();
            Archives = new Dictionary<string, string>();
        }
    }
}