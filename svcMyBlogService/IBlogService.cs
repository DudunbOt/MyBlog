using mdlMyBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svcMyBlogService
{
    public interface IBlogService
    {
        Blog Insert(Blog newBlog);
        List<Blog> GetAll();
        bool Update(Blog blog, int id);
        bool Delete(int id);
        Blog GetById(int id);
        long GetCount();
        List<string> GetErrors();
    }
}
