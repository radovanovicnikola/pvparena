using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arena.Entiteti;
using FluentNHibernate.Mapping;

namespace Arena.Mapiranja
{
    public class HeroMap : ClassMap<Entiteti.Hero>
    {
        public HeroMap() {

            Table("HERO");
            //mapiranje primarnog kljuca
            Id(x => x.Id, "HEROID").GeneratedBy.Identity();



            //mapiranje svojstava.
            Map(x => x.ArmorUp, "ARMOR_UP");
            Map(x => x.AttackUp, "ATTACK_UP");
            Map(x => x.SpeedUp, "SPEED_UP");

            References(x => x.User).Column("USERNAME4");
            References(x => x.HType).Column("TYPEID5");

        }
    }
}
