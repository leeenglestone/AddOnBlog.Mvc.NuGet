using AddOnBlog.Mvc.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Tests
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void Configuration_Post_Save_Path()
        {
            var postSavePath = AddOnBlogSettings.Settings.PostSavePath;


            Assert.IsNotNullOrEmpty(postSavePath);

            Console.WriteLine(postSavePath);
        }
    }
}
