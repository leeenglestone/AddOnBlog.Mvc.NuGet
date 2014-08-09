using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Library;
using AddOnBlog.Mvc.Models;
using AddOnBlog.MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddOnBlog.MvcApplication.Controllers
{
    public class BlogController : Controller
    {
        IBlogRepository _blogRepository  = new BlogRepository();

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Posts()
        {
            var posts = new PostsViewModel();

            //_blogRepository = new BlogRepository();

            posts.Posts = _blogRepository.GetAll();

            return View(posts);
        }

        /// <summary>
        /// View a blog post
        /// </summary>
        /// <returns></returns>
        public ActionResult Post(string id)
        {
            var model = new PostViewModel();

            model = Convert(_blogRepository.Get(id));

            return View(model);
        }

        [Authorize]
        public ActionResult Add(PostViewModel model)
        {
            if(ModelState.IsValid)
            {

            }

            return View(model);
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            // Check blog post id belongs to current user

            return View("Posts");
        }

        [Authorize]
        public ActionResult Edit(string id)
        {
            // Check blog post id belongs to current user

            var model = new PostViewModel();

            model = Convert(_blogRepository.Get(id));

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.Update(model.Post);

                return RedirectToAction("Posts");
            }

            return View(model);
        }

        private PostViewModel Convert(IPost post)
        {
            var model = new PostViewModel();
            model.Post.Content = post.Content;
            model.Post.Title = post.Title;
            model.Post.Id = post.Id;
            model.Post.PostDate = post.PostDate;
                
            return model;
        }

    }
}