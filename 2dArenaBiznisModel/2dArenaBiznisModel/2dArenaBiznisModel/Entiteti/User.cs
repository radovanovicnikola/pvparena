using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena.Entiteti
{
    public class User
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual int Experiance { get; set; }
        public virtual DateTime RegistarDate { get; set; }

        public virtual IList<Game> Played { get; set; }
        public virtual IList<Hero> Have { get; set; }

        public User() {
            Played = new List<Game>();
            Have = new List<Hero>();
        }
    }
}
