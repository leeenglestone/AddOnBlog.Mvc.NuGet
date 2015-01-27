using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Models;

namespace AddOnBlog.MvcApplication.Models
{
    public class PostViewModel
    {
        //public string Archives { get; set; }
        public Dictionary<string,string> Archives { get; set; }
        
        //public string BlogTags { get; set; }
        public List<string> BlogTags { get; set; }

        public PostViewModel(IPost post)
        {
            Post = post;
        }

        public PostViewModel()
        {
            Post = new Post();
            BlogTags = new List<string>();
            Archives = new Dictionary<string, string>();
        }

        public IPost Post { get; set; }
    }
    
}