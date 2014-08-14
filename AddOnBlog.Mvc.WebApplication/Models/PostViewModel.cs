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
        public PostViewModel(IPost post)
        {
            Post = post;
        }

        public PostViewModel()
        {
            Post = new Post();
        }

        public IPost Post { get; set; }
    }
}