using bosvcMyBlogService;
using svcMyBlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private IBlogService _blogService;
        private ILoginService _loginService;

        public HomeController()
        {
            _blogService = new BlogService();
            _loginService = new LoginService();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(FormCollection param)
        {
            string username = param["Username"];
            string password = param["Password"];

            if(_loginService.GetUser(username, password) == false)
            {
                return View();
            }

            Session["Username"] = username;
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var BlogList = _blogService.GetAll();
            ViewBag.count = _blogService.GetCount();
            return View(BlogList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}