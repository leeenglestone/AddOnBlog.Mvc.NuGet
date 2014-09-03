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
        IBlogRepository _blogRepository = new BlogRepository();

        // GET: Blog
        public ActionResult Index()
        {
            var model = new BlogViewModel();
            model.Posts = _blogRepository.GetAll();

            for (int x = 0; x < 12; x++)
            {
                var date =DateTime.Now.AddMonths(-x);

                model.Archives.Add("/blog/archive/" + date.ToString("MM-yyyy"), date.ToString("MMM yyyy"));
            }

            return View(model);
        }

        public ActionResult Posts()
        {
            var posts = new PostsViewModel();

            posts.Posts = _blogRepository.GetAll();

            return View(posts);
        }

        public ActionResult Post(string id)
        {
            var model = new PostViewModel();

            model = Convert(_blogRepository.Get(id));

            return View(model);
        }

        public ActionResult Archive(string id)
        {
            var model = new BlogViewModel();
            model.Posts = _blogRepository.GetArchive(id);

            for (int x = 0; x < 12; x++)
            {
                var date = DateTime.Now.AddMonths(-x);

                model.Archives.Add("/blog/archive/" + date.ToString("MM-yyyy"), date.ToString("MMM yyyy"));
            }

            return View(model);
        }

        [Authorize(Users="addonblog")]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)] 
        [HttpPost]
        [Authorize(Users = "addonblog")]
        public ActionResult Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.Add(model.Post);
            }

            var posts = new PostsViewModel();
            posts.Posts = _blogRepository.GetAll();

            return View("Posts", posts);
        }

        [Authorize(Users = "addonblog")]
        public ActionResult Delete(string id)
        {
            _blogRepository.Delete(id);

            var posts = new PostsViewModel();
            posts.Posts = _blogRepository.GetAll();

            return View("Posts", posts);
        }

        [Authorize(Users = "addonblog")]
        public ActionResult Edit(string id)
        {
            var model = new PostViewModel();

            model = Convert(_blogRepository.Get(id));

            return View(model);
        }

        [ValidateInput(false)]     
        [Authorize(Users = "addonblog")]
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
            model.Post.Categories = post.Categories;
            model.Post.Author = post.Author;
            model.Post.AuthorLink = post.AuthorLink;

            return model;
        }
    }
}