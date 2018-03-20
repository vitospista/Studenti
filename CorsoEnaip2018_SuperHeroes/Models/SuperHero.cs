using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.Models
{
    public class SuperHero
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("El nome de figon")]
        public string Name { get; set; }

        [Required]
        [DisplayName("El nome sconto")]
        public string SecretName { get; set; }

        [Range(typeof(DateTime), "1/1/1800", "1/1/2018")]
        [DisplayName("Quando che el xè nato")]
        public DateTime Birth { get; set; }

        [Range(1, int.MaxValue)]
        [DisplayName("Quanto che el pesta")]
        public int Strength { get; set; }

        [DisplayName("El svola")]
        public bool CanFly { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Quanti mati el gà copà")]
        public int KilledVillains { get; set; }
    }
}
