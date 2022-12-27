using daoInSQLMyBlog;
using mdlMyBlog;
using svcMyBlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bosvcMyBlogService
{
    public class BlogService : IBlogService
    {
        private readonly IBlogDao _BlogDao;
        private readonly List<string> _errors;

        public BlogService()
        {
            _BlogDao = new InSQLBlogDao();
            _errors = new List<string>();
        }

        public bool Delete(int id)
        {
            return _BlogDao.Delete(id);
        }

        public List<Blog> GetAll()
        {
            return _BlogDao.GetAll();
        }

        public Blog GetById(int id)
        {
            return _BlogDao.GetById(id);
        }

        public long GetCount()
        {
            return _BlogDao.GetCount();
        }

        public List<string> GetErrors()
        {
            return _errors;
        }

        public Blog Insert(Blog newBlog)
        {
            return _BlogDao.Insert(newBlog);
        }

        public bool Update(Blog blog, int id)
        {
            return _BlogDao.Update(blog, id);
        }
    }
}
