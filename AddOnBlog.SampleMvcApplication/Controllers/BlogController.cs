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
		[OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var model = new BlogViewModel
            {
                Posts = _blogRepository.GetAll().OrderByDescending(x => x.PostDate).ToList(),
                Archives = GetArchives()
            };

            return View(model);
        }

		private Dictionary<string, string> GetArchives()
        {
            var model = new Dictionary<string, string>();

            for (int x = 0; x < 12; x++)
            {
                var date = DateTime.Now.AddMonths(-x);
                model.Add("/blog/archive/" + date.ToString("MM-yyyy"), date.ToString("MMMM yyyy"));
            }

            return model;
        }
		[OutputCache(Duration = 60)]
        public ActionResult Posts()
        {
            var posts = new PostsViewModel
            {
                Posts = _blogRepository.GetAll().OrderByDescending(x => x.PostDate).ToList(),
                Archives = GetArchives()
            };

            return View(posts);
        }

		[OutputCache(Duration = 60)]
        public ActionResult Post(string id)
        {
            var post = _blogRepository.Get(id);

            if(post == null)
            {
                return View(new PostViewModel());
            }

            ViewBag.MetaDescription = post.Title;
            ViewBag.MetaKeywords = post.Title;

            var model = Convert(post);
            model.Archives = GetArchives();

            return View(model);
        }

		[OutputCache(Duration = 60)]
        public ActionResult Archive(string id)
        {
            var model = new BlogViewModel
            {
                ArchiveId = id,
                Posts = _blogRepository.GetArchive(id),
                Archives = GetArchives()
            };

            return View(model);
        }

		[OutputCache(Duration = 60)]
        public ActionResult Category(string id)
        {
            var model = new BlogViewModel
            {
                Category = id,
                Posts = _blogRepository.GetCategory(id.ToLower()),
                Archives = GetArchives()
            };
           
            return View(model);
        }

        [Authorize(Users="addonblog")]
        public ActionResult Create()
        {
            var model = new PostViewModel
            {
                Post = new Post{
                    PostDate = DateTime.Now
                }
            };

            return View(model);
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

            var posts = new PostsViewModel
            {
                Posts = _blogRepository.GetAll()
            };

            return View("Posts", posts);
        }

        [Authorize(Users = "addonblog")]
        public ActionResult Delete(string id)
        {
            _blogRepository.Delete(id);

            var posts = new PostsViewModel
            {
                Posts = _blogRepository.GetAll()
            };

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
            var model = new PostViewModel
            {
                Post = new Post
                {
                    Content = post.Content,
                    Title = post.Title,
                    Id = post.Id,
                    PostDate = post.PostDate,
                    Categories = post.Categories,
                    Author = post.Author,
                    AuthorLink = post.AuthorLink
                }
            };

            return model;
        }
    }
}
