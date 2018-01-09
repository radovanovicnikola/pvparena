using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arena.Entiteti;
using FluentNHibernate.Mapping;

namespace Arena.Mapiranja
{
    public class MapMapcs: ClassMap<Entiteti.Map>
    {
        public MapMapcs()
        {

            Table("MAP");
            //mapiranje primarnog kljuca
            Id(x => x.MapId, "MAPID").GeneratedBy.Identity();



            //mapiranje svojstava.
            Map(x => x.MapName, "MAPNAME");
            Map(x => x.MaxPlayer, "MAXPLAYER");

            HasMany(x => x.PlayedIn).KeyColumn("MAPID6").Inverse().Cascade.SaveUpdate();
        }
    }
}
