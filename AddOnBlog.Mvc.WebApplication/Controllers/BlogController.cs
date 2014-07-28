using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddOnBlog.MvcApplication.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// View a blog post
        /// </summary>
        /// <returns></returns>
        public ActionResult View(string id)
        {
            return View();
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        



        
    }
}