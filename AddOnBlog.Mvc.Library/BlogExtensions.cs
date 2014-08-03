using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Library
{
    public static class BlogExtensions
    {
        public static string ToFriendlyUrl(this string title)
        {
            return title.ToLower()
                .Replace(" ", "-")
                .Replace("'", "")
                .Replace(",", "")
                .Replace(".", "")
                .Replace("&", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("%", "");
        }
    }
}
