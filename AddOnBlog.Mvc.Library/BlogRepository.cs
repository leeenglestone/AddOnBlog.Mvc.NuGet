using AddOnBlog.Mvc.Interfaces;
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
            throw new NotImplementedException();
        }

        public IPost Add(IPost post)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Post));

            var path = "";

            using(TextWriter WriteFileStream = new StreamWriter(path))
            {
                serializer.Serialize(WriteFileStream, post);

            }

            return post;

            throw new NotImplementedException();
        }

        public IPost Update(IPost post)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<IPost> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
