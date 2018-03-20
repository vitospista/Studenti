using System.ComponentModel.DataAnnotations.Schema;

namespace CorsoEnaip2018_SuperHeroes.Models
{
    public class Villain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Killed { get; set; }

        public int NemesisId { get; set; }
        public SuperHero Nemesis { get; set; }
    }
}
