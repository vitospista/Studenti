using CorsoEnaip2018_AspNetCoreTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_AspNetCoreTest1.DataAccess
{
    public interface IRepository
    {
        List<Item> GetList();
    }
}
