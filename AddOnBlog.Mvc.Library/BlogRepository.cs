using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddOnBlog.Mvc.Library
{
    public class BlogRepository : IBlogRepository
    {
        public IPost Get(string id)
        {
            Post post;

            var path = AddOnBlogSettings.Settings.PostSavePath + id + ".xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            using (TextReader ReadFileStream = new StreamReader(path))
            {
                post = (Post)serializer.Deserialize(ReadFileStream);
            }

            return post;
        }

        public IPost Add(IPost post)
        {
            // Set id
            // 
            post.Id = post.Title.ToFriendlyUrl();

            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            var path = AddOnBlogSettings.Settings.PostSavePath + post.Id + ".xml";
            post.SavePath = path;

            // Check whether the file already exists
            if(File.Exists(path))
            {
                throw new Exception("Cannot create post, a post with that title already exists!");
            }

            using (TextWriter WriteFileStream = new StreamWriter(path))
            {
                serializer.Serialize(WriteFileStream, post);
            }

            return post;
        }

        public IPost Update(IPost post)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            var path = AddOnBlogSettings.Settings.PostSavePath + post.Id + ".xml";
            post.SavePath = path;

            using (TextWriter WriteFileStream = new StreamWriter(path))
            {
                serializer.Serialize(WriteFileStream, post);
            }

            return post;
        }

        public bool Delete(string id)
        {
            var path = AddOnBlogSettings.Settings.PostSavePath + id + ".xml";

            File.Delete(path);

            return true;
        }

        public List<IPost> GetAll()
        {
            List<IPost> posts = new List<IPost>();

            var path = AddOnBlogSettings.Settings.PostSavePath;

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
    }
}
