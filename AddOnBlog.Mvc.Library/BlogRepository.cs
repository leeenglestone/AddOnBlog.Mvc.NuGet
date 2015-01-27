using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace AddOnBlog.Mvc.Library
{
    public class BlogRepository : IBlogRepository
    {
        public string PostSavePath()
        {
            if (HttpContext.Current == null)
            {
                return AddOnBlogSettings.Settings.PostSavePath;
            }

            var path = System.Web.HttpContext.Current.Server.MapPath(AddOnBlogSettings.Settings.PostSavePath);

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public IPost Get(string id)
        {
            Post post;

            var path = Path.Combine(PostSavePath(), id + ".xml");

            if(!File.Exists(path))
            {
                return new Post();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            using (TextReader ReadFileStream = new StreamReader(path))
            {
                post = (Post)serializer.Deserialize(ReadFileStream);
            }

            return post;
        }

        public IPost Add(IPost post)
        {
            if(String.IsNullOrEmpty(post.Title))
            {
                throw new ArgumentNullException("post.Title");
            }

            post.Id = post.Title.ToFriendlyUrl();
            post.FriendlyUrl = post.Title.ToFriendlyUrl();
            
            if(String.IsNullOrEmpty(post.Id))
            {
                throw new ArgumentNullException("post.Id");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            var path = Path.Combine(PostSavePath(), post.Id + ".xml");
            post.SavePath = path;

            // Check whether the file already exists
            if(File.Exists(path))
            {
                throw new Exception("Cannot create post, a post with that title already exists!");
            }

            using (XmlTextWriter WriteFileStream = new XmlTextWriter(path, Encoding.UTF8))
            {
                serializer.Serialize(WriteFileStream, (Post)post);
            }

            return post;
        }

        public IPost Update(IPost post)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            var path = Path.Combine(PostSavePath(), post.Id + ".xml");
            post.SavePath = path;

            if (String.IsNullOrEmpty(post.Id))
            {
                throw new ArgumentNullException("post.Id");
            }

            using (XmlTextWriter WriteFileStream = new XmlTextWriter(path, Encoding.UTF8))
            {
                serializer.Serialize(WriteFileStream, post);
            }

            return post;
        }

        public bool Delete(string id)
        {
            var path = Path.Combine(PostSavePath(), id + ".xml");

            File.Delete(path);

            return true;
        }

        public List<IPost> GetAll()
        {
            List<IPost> posts = new List<IPost>();

            var path = PostSavePath();

            var postFiles = Directory.GetFiles(path);

            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            foreach (var file in postFiles)
            {
                using (TextReader ReadFileStream = new StreamReader(file))
                {
                    Post post = (Post)serializer.Deserialize(ReadFileStream);

                    posts.Add(post);
                }
            }

            return posts;
        }

        public List<IPost> GetArchive(string period)
        {
            var parts = period.Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);

            int month = int.Parse(parts[0]);
            int year = int.Parse(parts[1]);

            List<IPost> posts = GetAll().Where(x => x.PostDate.Month == month && x.PostDate.Year == year).ToList();

            return posts;
        }

        public List<IPost> GetCategory(string category)
        {
            var posts = GetAll().Where(x => !String.IsNullOrEmpty(x.Categories));

            posts = posts.Where(x => x.Categories.ToLower().Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries).Contains(category));

            //List<IPost> posts = GetAll().Where(x => x.Categories.Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries).Contains(category)).ToList();

            return posts.ToList();
        }
    }
}
