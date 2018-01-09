using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arena.Entiteti;
using FluentNHibernate.Mapping;

namespace Arena.Mapiranja
{
    public class HeroTypeMap:ClassMap<Entiteti.HeroType>
    {
        public HeroTypeMap()
        {

            Table("HERO_TYPE");
            //mapiranje primarnog kljuca
            Id(x => x.Id, "TYPEID").GeneratedBy.Identity();



            //mapiranje svojstava.
            Map(x => x.Name, "NAME");
            Map(x => x.Armor, "ARMOR");
            Map(x => x.Attack, "ATTACK");
            Map(x => x.Speed, "SPEED");
            
            HasMany(x => x.Hero).KeyColumn("TYPEID5").Inverse().Cascade.SaveUpdate();
        }
    }
}
