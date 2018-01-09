using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Entiteti
{
    public class Map
    {
        public virtual string MapName { get; set; }
        public virtual int MaxPlayer { get; set; }
        public virtual int MapId { get; set; }
        public virtual IList<Game> PlayedIn { get; set; }

        public Map() {
            PlayedIn = new List<Game>();
        }


    }
}
