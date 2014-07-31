using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Models;
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

        [TestFixtureSetUp]
        public void SetUp()
        {
            // Dependency injection using Ninject
        }

        [Test]
        public void Posts_Get_All()
        {
            throw new NotImplementedException();

            var posts = _blogRepository.GetAll();

            Assert.Greater(posts.Count, 0);
        }

        [Test]
        public void Post_Add()
        {
            throw new NotImplementedException();

            IPost post = new Post
            {
                Title = "Some title"
            };

            var newPost = _blogRepository.Add(post);

            Assert.IsNotEmpty(newPost.Title);
        }

        [Test]
        public void Post_Update()
        {
            string friendlyUrl = "";

            var post = _blogRepository.Get(friendlyUrl);

            throw new NotImplementedException();
        }

        [Test]
        public void Post_Delete()
        {
            throw new NotImplementedException();
        }
    }
}
