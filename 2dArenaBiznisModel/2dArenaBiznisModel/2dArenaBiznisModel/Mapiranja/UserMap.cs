using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arena.Entiteti;
using FluentNHibernate.Mapping;

namespace Arena.Mapiranja
{
    public class UserMap : ClassMap<Entiteti.User>
    {
        public UserMap()
        {
            Table("USER");

            Id(x => x.UserName, "USERNAME");



            //mapiranje svojstava.
            Map(x => x.Password, "PASSWORD");
            Map(x => x.Experiance, "EXPERIANCE");
            Map(x => x.RegistarDate, "REGISTERDATE");

            HasMany(x => x.Played).KeyColumn("USERNAME5").Inverse().Cascade.All();
            HasMany(x => x.Have).KeyColumn("USERNAME4").Inverse().Cascade.All();


        }
    }
}
