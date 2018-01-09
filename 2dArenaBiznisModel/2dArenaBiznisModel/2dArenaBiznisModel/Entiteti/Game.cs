using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Entiteti
{
    public class Game
    {
        public virtual int Kills { get; set; }
        public virtual int Deths { get; set; }
        public virtual DateTime DatePlayed { get; set; }
        public virtual int GameId { get; set; }
        public virtual int ErnedExp {get; set;}
        public virtual User User { get; set; }
        public virtual Map Map { get; set; }
        public virtual HeroType HType { get; set; }


        public Game() { }

    }
}
