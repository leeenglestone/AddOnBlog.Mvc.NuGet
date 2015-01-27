using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddOnBlog.MvcApplication.Models
{
    public class BlogItemViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string[] Categories { get; set; }
        public DateTime? DateTime { get; set; }
        public bool Shorten { get; set; }

        public List<string> BlogTags { get; set; }

        public Dictionary<DateTime, int> Archives { get; set; }

        public BlogItemViewModel()
        {
            BlogTags = new List<string>();
            Archives = new Dictionary<DateTime, int>();
        }
    }
   
}