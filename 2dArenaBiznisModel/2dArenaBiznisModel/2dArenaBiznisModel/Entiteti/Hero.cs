using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Entiteti
{
    public class Hero
    {
        public virtual float ArmorUp { get; set; }
        public virtual float AttackUp { get; set; }
        public virtual float SpeedUp { get; set; }
        public virtual int Id { get; set; }

        public virtual User User { get; set; }
        public virtual HeroType HType { get; set; }

        public Hero() { }
    }
}
