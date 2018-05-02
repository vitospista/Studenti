using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CorsoEnaip2018_AspNetCoreTest1.Controllers;
using CorsoEnaip2018_AspNetCoreTest1.DataAccess;
using CorsoEnaip2018_AspNetCoreTest1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorsoEnaip2018_AspNetCoreTest1.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void does_not_catch_Repository_errors()
        {
            var c = new HomeController(new MockRepositoryException());

            c.Index();
        }

        [TestMethod]
        public void shows_View_with_Items_from_Repository()
        {
            var c = new HomeController(new MockRepositoryOk());

            var view = c.Index() as ViewResult;
            Assert.IsNotNull(view);

            var models = view.Model as List<Item>;
            Assert.IsNotNull(models);

            Assert.AreEqual(2, models.Count);
            Assert.AreEqual("Item 1", models[0].Name);
            Assert.AreEqual(1234.32123, models[1].Value, 0.000001);
        }
    }

    class MockRepositoryException : IRepository
    {
        public List<Item> GetList()
        {
            throw new NotImplementedException();
        }
    }

    class MockRepositoryOk : IRepository
    {
        public List<Item> GetList()
        {
            return new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Item 1",
                    Value = 0.5,
                    Created = DateTime.Now,
                },
                new Item
                {
                    Id = 2,
                    Name = "Item 2",
                    Value = 1234.32123,
                    Created = DateTime.Now.AddDays(-5),
                }
            };
        }
    }
}
