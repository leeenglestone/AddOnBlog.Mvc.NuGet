using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AddOnBlog.Mvc.Interfaces;

namespace AddOnBlog.MvcApplication.Models
{
    public class PostsViewModel
    {
        public PostsViewModel()
        {
            Archives = new Dictionary<string, string>();
            BlogTags = new List<string>();
        }

        public Dictionary<string, string> Archives { get; set; }
        public List<string> BlogTags { get; set; }

        public IList<IPost> Posts { get; set; }
    }
}