using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Library;
using AddOnBlog.Mvc.Models;
using Ninject;
using Ninject.Modules;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Tests
{
    public class PostTests 
    {
        IBlogRepository _blogRepository;
        IKernel kernel;

        [TestFixtureSetUp]
        public void SetUp()
        {
            kernel = new StandardKernel();
            kernel.Bind<IBlogRepository>().To<BlogRepository>();

            _blogRepository = kernel.Get<IBlogRepository>();
        }

        [Test]
        public void Posts_Get_All()
        {
            var posts = _blogRepository.GetAll();

            Assert.Greater(posts.Count, 0);

            Console.WriteLine("Posts_Get_All() : Count={0}", posts.Count);

            foreach(var p in posts)
            {
                Console.WriteLine(p.Id);
            }
        }

        [Test]
        public void Posts_Get()
        {
            var posts = _blogRepository.GetAll();

            var post = _blogRepository.Get(posts.First().Id);

            Assert.IsNotNullOrEmpty(post.Content);

            Console.WriteLine("Posts_Get() : {0}", post.Title);
        }

        [Test]
        public void Post_Add()
        {
            IPost post = new Post
            {
                Title = "Some title " + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Content = "Some content"
            };

            var newPost = _blogRepository.Add(post);

            Assert.IsNotEmpty(newPost.Title);

            Console.WriteLine("Post_Add() : Path={0}", newPost.SavePath);
        }

        [Test]
        public void Post_Update()
        {
            string postId = _blogRepository.GetAll().FirstOrDefault().Id;

            // Get post
            var post = _blogRepository.Get(postId);
            var originalContent = post.Content;

            // Update post
            var newContent = DateTime.Now.ToString("yyyy-MM-dd HHmmss");
            post.Content = newContent;
            _blogRepository.Update(post);

            // Retrieve post
            var retrievedContent = _blogRepository.Get(postId).Content;

            Assert.AreEqual(newContent, retrievedContent);

            Console.WriteLine("Post_Update() : Post updated");
        }

        [Test]
        public void Post_Delete()
        {
            var originalCount = _blogRepository.GetAll().Count;

            // Add post
            IPost post = new Post
            {
                Title = "Some title " + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Content = "Some content"
            };

            var newPost = _blogRepository.Add(post);

            var countAfterAdd = _blogRepository.GetAll().Count;

            Assert.Greater(countAfterAdd, originalCount);

            // Delete post
            _blogRepository.Delete(newPost.Id);

            // Check deletion
            var countAfterDeletion = _blogRepository.GetAll().Count;

            Assert.AreEqual(originalCount, countAfterDeletion);

            Console.WriteLine("Post_Delete()");
        }
    }
}
