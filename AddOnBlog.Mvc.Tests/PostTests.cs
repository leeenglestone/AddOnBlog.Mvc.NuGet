using AddOnBlog.Mvc.Interfaces;
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
        }
    }
}
