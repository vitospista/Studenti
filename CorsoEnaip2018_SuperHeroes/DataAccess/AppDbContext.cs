using CorsoEnaip2018_SuperHeroes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Villain> Villains { get; set; }
    }
}
