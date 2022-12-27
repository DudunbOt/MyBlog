using bosvcMyBlogService;
using mdlMyBlog;
using svcMyBlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;

        public BlogController()
        {
            _blogService = new BlogService();
        }

        public Blog BindData(Blog blog, FormCollection param)
        {
            blog.Title = param["Title"];
            blog.TitleDesc = param["TitleDesc"];
            blog.Content = param["Content"];
            blog.CreatedAt = param["CreatedAt"];
            blog.UpdatedAt = param["UpdatedAt"];
            blog.Author = param["Author"];

            return blog;
        }

        public ActionResult Create()
        {
            Blog blog = new Blog();
            blog.CreatedAt = DateTime.Now.ToString();
            blog.UpdatedAt = DateTime.Now.ToString();

            return View(blog);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(FormCollection param)
        {
            Blog blog = new Blog();
            BindData(blog, param);

            if(_blogService.Insert(blog) == null)
            {
                var err = _blogService.GetErrors();
                foreach (var item in err)
                    ModelState.AddModelError(Guid.NewGuid().ToString(), item);

                return View(blog);
            }

            return RedirectToAction("Index","Home", "Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = _blogService.GetById(id);
            if (data == null)
                return RedirectToAction("Index", "Home", "Index");

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = _blogService.GetById(id);
            if (data == null)
                return RedirectToAction("Index", "Home", "Index");

            return View(data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(FormCollection param, int id)
        {
            var data = _blogService.GetById(id);
            if(data == null)
                return RedirectToAction("Index", "Home", "Index");

            BindData(data, param);

            if(_blogService.Update(data,id) == false)
            {
                var err = _blogService.GetErrors();
                foreach (var item in err)
                    ModelState.AddModelError(Guid.NewGuid().ToString(), item);

                return View(data);
            }

            return RedirectToAction("Details", "Blog", new { id = id});
        }

        public ActionResult Delete(int id)
        {
            var data = _blogService.GetById(id);
            if(data == null)
                return RedirectToAction("Index", "Home", "Index");

            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var data = _blogService.GetById(id);
            if (data == null)
                return RedirectToAction("Index", "Home", "Index");

            if(_blogService.Delete(id) == false)
            {
                var err = _blogService.GetErrors();
                foreach (var item in err)
                    ModelState.AddModelError(Guid.NewGuid().ToString(), item);

                return View(data);
            }

            return RedirectToAction("Index", "Home", "Index");
        }
    }
}