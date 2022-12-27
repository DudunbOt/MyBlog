using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mdlMyBlog;
using System.Threading.Tasks;

namespace daoInSQLMyBlog
{
    public class InSQLUserDao : ILoginDao
    {
        myBlogEntities Db = new myBlogEntities();
        public bool getUser(string username, string password)
        {
            if (!Db.Users.Any(e => e.Username == username) && !Db.Users.Any(e => e.Password == password))
                return false;
                

            return true;
        }

    }
}
