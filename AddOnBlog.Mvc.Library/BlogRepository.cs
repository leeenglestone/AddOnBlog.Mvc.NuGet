using AddOnBlog.Mvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
