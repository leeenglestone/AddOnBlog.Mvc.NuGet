using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AddOnBlog.Mvc.Interfaces;

namespace $rootnamespace$.MvcApplication.Models
{
    public class PostsViewModel
    {
        public IList<IPost> Posts { get; set; }
    }
}