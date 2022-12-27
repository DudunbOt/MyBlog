using bosvcMyBlogService;
using mdlMyBlog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using svcMyBlogService;
using System;

namespace UnitTestMyBlog
{
    [TestClass]
    public class TestService
    {
        [TestMethod]
        public void InsertTest()
        {
            var data = new Blog()
            {
                Title = "NewTitle4",
                TitleDesc = "NewTitleDesc4",
                Content = "NewContent4",
                CreatedAt = DateTime.Now.ToString(),
                UpdatedAt = DateTime.Now.ToString(),
                Author = "NewAuthor4"
            };

            IBlogService blogDao = new BlogService();
            var actual = blogDao.Insert(data);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var data = new Blog()
            {
                Title = "NewTitle",
                TitleDesc = "NewTitleDesc",
                Content = "NewContent",
                CreatedAt = DateTime.Now.ToString(),
                UpdatedAt = DateTime.Now.ToString(),
                Author = "NewAuthor"
            };

            IBlogService blogDao = new BlogService();
            var actual = blogDao.Insert(data);

            Assert.IsNotNull(actual);

            var result = blogDao.Delete(actual.id);
            Assert.IsTrue(result);

            actual = blogDao.GetById(actual.id);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void UpdateTest()
        {
            IBlogService blogService = new BlogService();
            var actual = blogService.GetById(8);

            var expected = new Blog()
            {
                Title = "EditedTitle3",
                TitleDesc = "EditedTitleDesc3",
                Content = "EditedContent3",
                UpdatedAt = DateTime.Now.ToString(),
                Author = "EditedAuthor3"
            };

            actual.Title = expected.Title;
            actual.TitleDesc = expected.TitleDesc;
            actual.Content = expected.Content;
            actual.UpdatedAt = expected.UpdatedAt;
            actual.Author = expected.Author;

            var result = blogService.Update(actual, actual.id);
            Assert.IsTrue(result);

            actual = blogService.GetById(actual.id);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.TitleDesc, actual.TitleDesc);
            Assert.AreEqual(expected.Content, actual.Content);
            Assert.AreEqual(expected.UpdatedAt, actual.UpdatedAt);
            Assert.AreEqual(expected.Author, actual.Author);
        }
    }
}
