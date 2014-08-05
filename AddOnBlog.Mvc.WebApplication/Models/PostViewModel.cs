using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AddOnBlog.Mvc.Interfaces;

namespace AddOnBlog.MvcApplication.Models
{
    public class PostViewModel
    {
        public IPost Post { get; set; }
    }
}