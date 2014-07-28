using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Interfaces
{
    public interface IBlogRepository
    {
       IPost Get(string id);
       IPost Add(IPost post);
       IPost Update(IPost post);
       bool Delete(string id);
    }
}
