using CorsoEnaip2018_SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    public class SuperHeroInMemoryRepository
        : IRepository<SuperHero>
    {
        private List<SuperHero> _models;

        public SuperHeroInMemoryRepository()
        {
            _models = new List<SuperHero>();
        }

        public bool Delete(SuperHero model)
        {
            return _models.Remove(model);
        }

        public SuperHero Find(int id)
        {
            return _models.FirstOrDefault(x => x.Id == id);
        }

        public List<SuperHero> FindAll()
        {
            return _models.ToList();
        }

        public void Insert(SuperHero model)
        {
            var maxId = _models.Count > 0
                ? _models.Max(x => x.Id)
                : 0;

            model.Id = maxId + 1;

            _models.Add(model);
        }

        public bool Update(SuperHero model)
        {
            var index = _models.FindIndex(x => x.Id == model.Id);

            // posso controllare le condizioni e restituire il risultato
            // in due modi diversi.
            // questo è il primo:
            var isIndexValid = index > -1;

            if (isIndexValid)
                _models[index] = model;

            return isIndexValid;


            // questo è il secondo:
            //if (index == -1)
            //    return false;

            //_models[index] = model;

            //return true;
        }
    }
}
