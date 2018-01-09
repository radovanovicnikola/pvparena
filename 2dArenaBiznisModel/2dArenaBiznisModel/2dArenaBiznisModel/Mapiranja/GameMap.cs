using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arena.Entiteti;
using FluentNHibernate.Mapping;

namespace Arena.Mapiranja
{
    public class GameMap:ClassMap<Entiteti.Game>
    {
        public GameMap()
        {

            Table("GAME");
            //mapiranje primarnog kljuca
            Id(x => x.GameId, "GAMEID").GeneratedBy.Identity();



            //mapiranje svojstava.
            Map(x => x.Kills, "KILLS");
            Map(x => x.Deths, "DEATHS");
            Map(x => x.DatePlayed, "DATEPLAYED");
            Map(x => x.ErnedExp, "ERNEDEXP");

            References(x => x.User).Column("USERNAME5");
            References(x => x.HType).Column("TYPEID7");
            References(x => x.Map).Column("MAPID6");

        }
    }
}
