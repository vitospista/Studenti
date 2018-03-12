using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    interface IRepository<T>
    {
        List<T> FindAll();
        T Find(int id);
        void Update(T model);
        void Insert(T model);
        void Delete(T model);
    }
}
