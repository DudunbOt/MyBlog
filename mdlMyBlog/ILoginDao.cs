using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdlMyBlog
{
    public interface ILoginDao
    {
        bool getUser(string username, string password);
    }
}
