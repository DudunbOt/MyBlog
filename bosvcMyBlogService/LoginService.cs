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
    public class LoginService : ILoginService
    {
        private readonly ILoginDao _loginDao;

        public LoginService()
        {
            _loginDao = new InSQLUserDao();
        }
        public bool GetUser(string Username, string Password)
        {
            return _loginDao.getUser(Username, Password);
        }
    }
}
