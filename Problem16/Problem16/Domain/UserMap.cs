namespace Problem16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentNHibernate.Mapping;

    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(user => user.Id).GeneratedBy.Guid();
            Map(user => user.FirstName);
            Map(user => user.SecondName);
            Map(user => user.Email);
            Component(user => user.Location, loc =>
            {
                loc.Map(l => l.Country);
                loc.Map(l => l.City);
                loc.Map(l => l.Adress);
            });
            HasMany(user => user.Posts)
                .Inverse()
                .Cascade.All();
            Table("users");
        }
    }
}
