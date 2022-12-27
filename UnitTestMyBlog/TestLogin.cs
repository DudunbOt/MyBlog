using daoInSQLMyBlog;
using mdlMyBlog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestMyBlog
{
    [TestClass]
    public class TestLogin
    {
        [TestMethod]
        public void GetUser()
        {
            var data = new User()
            {
                Username = "Pineda",
                Password = "qaswed123"
            };

            ILoginDao loginDao = new InSQLUserDao();
            var actual = loginDao.getUser(data.Username, data.Password);
            Assert.IsNotNull(actual);
        }
    }
}
