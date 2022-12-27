using mdlMyBlog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daoInSQLMyBlog
{
    public class InSQLBlogDao : IBlogDao
    {
        myBlogEntities Db = new myBlogEntities();
        public bool Delete(int id)
        {
            var data = GetById(id);
            if (data == null)
                return false;

            Db.Blogs.Remove(data);
            Db.SaveChanges();

            return true;
        }

        public List<Blog> GetAll()
        {
            return Db.Blogs.OrderByDescending(o => o.CreatedAt).ToList();
        }

        public Blog GetById(int id)
        {
            if (!Db.Blogs.Any(e => e.id == id))
                return null;

            return Db.Blogs.Where(e => e.id == id).FirstOrDefault();
        }

        public long GetCount()
        {
            return Db.Blogs.Count();
        }

        public Blog Insert(Blog newBlog)
        {
            Db.Blogs.Add(newBlog);
            Db.SaveChanges();

            return newBlog;
        }

        public bool Update(Blog blog, int id)
        {
            var data = GetById(id);
            if (data == null)
                return false;

            data.Title = blog.Title;
            data.TitleDesc = blog.TitleDesc;
            data.Content = blog.Content;
            data.UpdatedAt = DateTime.Now.ToString();
            data.Author = blog.Author;

            Db.Entry(data).State = EntityState.Modified;
            Db.SaveChanges();

            return true;
        }
    }
}
