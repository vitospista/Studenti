using CorsoEnaip2018_SuperHeroes.Models;
using System.Linq;

namespace CorsoEnaip2018_SuperHeroes.ViewModels
{
    public class SuperHeroRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public bool CanFly { get; set; }
        public int AssignedVillains { get; set; }
        public int KilledVillains { get; set; }

        public static SuperHeroRow Map(SuperHero model)
        {
            return new SuperHeroRow
            {
                Id = model.Id,
                Name = model.Name,
                Strength = model.Strength,
                CanFly = model.CanFly,
                AssignedVillains = model.Enemies.Count,
                KilledVillains = model.Enemies.Count(x => x.Killed)
            };
        }
    }
}
