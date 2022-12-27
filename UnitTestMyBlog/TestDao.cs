using daoInSQLMyBlog;
using mdlMyBlog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestMyBlog
{
    [TestClass]
    public class TestDao
    {
        [TestMethod]
        public void InsertTest()
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

            IBlogDao blogDao = new InSQLBlogDao();
            var actual = blogDao.Insert(data);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void UpdateTest()
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

            IBlogDao blogDao = new InSQLBlogDao();
            var actual = blogDao.Insert(data);

            Assert.IsNotNull(actual);

            var expected = new Blog()
            {
                Title = "EditedTitle2",
                TitleDesc = "EditedTitleDesc2",
                Content = "EditedContent2",
                UpdatedAt = DateTime.Now.ToString(),
                Author = "EditedAuthor2"
            };

            actual.Title = expected.Title;
            actual.TitleDesc = expected.TitleDesc;
            actual.Content = expected.Content;
            actual.UpdatedAt = expected.UpdatedAt;
            actual.Author = expected.Author;

            var result = blogDao.Update(actual, actual.id);
            Assert.IsTrue(result);

            actual = blogDao.GetById(actual.id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.TitleDesc, actual.TitleDesc);
            Assert.AreEqual(expected.Content, actual.Content);
            Assert.AreEqual(expected.UpdatedAt, actual.UpdatedAt);
            Assert.AreEqual(expected.Author, actual.Author);
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

            IBlogDao blogDao = new InSQLBlogDao();
            var actual = blogDao.Insert(data);

            Assert.IsNotNull(actual);

            var result = blogDao.Delete(actual.id);
            Assert.IsTrue(result);

            actual = blogDao.GetById(actual.id);
            Assert.IsNull(actual);
        }
    }
}
