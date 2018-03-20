using CorsoEnaip2018_SuperHeroes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    public class SuperHeroEntityFrameworkRepository : IRepository<SuperHero>
    {
        private AppDbContext _context;

        public SuperHeroEntityFrameworkRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(SuperHero model)
        {
            _context.SuperHeroes.Remove(model);

            var result = _context.SaveChanges();

            return result == 1;
        }

        public SuperHero Find(int id)
        {
            return _context.SuperHeroes.FirstOrDefault(x => x.Id == id);
        }

        public List<SuperHero> FindAll()
        {
            var models = _context.SuperHeroes.ToList();

            return models;
        }

        public void Insert(SuperHero model)
        {
            _context.SuperHeroes.Add(model);

            _context.SaveChanges();
        }

        public bool Update(SuperHero model)
        {
            _context.SuperHeroes.Update(model);

            var result = _context.SaveChanges();

            return result == 1;
        }
    }
}
