using CorsoEnaip2018_SuperHeroes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    public class VillainEntityFrameworkRepository : IRepository<Villain>
    {
        private AppDbContext _context;

        public VillainEntityFrameworkRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(Villain model)
        {
            _context.Villains.Remove(model);

            var result = _context.SaveChanges();

            return result == 1;
        }

        public Villain Find(int id)
        {
            return _context.Villains.FirstOrDefault(x => x.Id == id);
        }

        public List<Villain> FindAll()
        {
            var models = _context.Villains
                .Include(x => x.Nemesis)
                .ToList();

            return models;
        }

        public void Insert(Villain model)
        {
            _context.Villains.Add(model);

            _context.SaveChanges();
        }

        public bool Update(Villain model)
        {
            _context.Villains.Update(model);

            var result = _context.SaveChanges();

            return result == 1;
        }
    }
}
