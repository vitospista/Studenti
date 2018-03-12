using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretName { get; set; }
        public DateTime Birth { get; set; }
        public int Strength { get; set; }
        public bool CanFly { get; set; }
        public int KilledVillains { get; set; }
    }
}
