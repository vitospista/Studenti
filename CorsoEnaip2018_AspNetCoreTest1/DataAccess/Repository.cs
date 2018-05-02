using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoEnaip2018_AspNetCoreTest1.Models;

namespace CorsoEnaip2018_AspNetCoreTest1.DataAccess
{
    public class Repository : IRepository
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
