using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Entiteti
{
    public class HeroType
    {
        public virtual string Name { get; set; }
        public virtual float Armor { get; set; }
        public virtual float Attack { get; set;}
        public virtual float Speed { get; set; }
        public virtual int Id { get; set; }

        public virtual IList<Game> PlayedIn { get; set; }
        public virtual IList<Hero> Hero { get; set; }

        public HeroType() {
            PlayedIn = new List<Game>();
            Hero = new List<Hero>();
        }
    }
}
