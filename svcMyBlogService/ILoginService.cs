using mdlMyBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svcMyBlogService
{
    public interface ILoginService
    {
        bool GetUser(string Username, string Password);
    }
}
