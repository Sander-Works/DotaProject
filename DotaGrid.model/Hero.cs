using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotaGrid.Model
{
   
    [Table("Hero")]
    public class Hero
    {
        [Required]
        public int HeroId { get; set; }
        public string Name { get; set; }
       
        public string Q { get; set; }
        public string W { get; set; }
        public string E { get; set; }
        public string Ultimate { get; set; }
        public int Hp { get; set; }
        public int Mana { get; set; }
        public int Ms { get; set; }
        public int Armor { get; set; }

        public Mainattribute Mainattribute { get; set; }

        public string ShortDescription => $"Hero: {Name}";
        public string Playstyle { get; set; }
    }
}
