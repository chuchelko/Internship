namespace Problem23.Entities.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentNHibernate.Mapping;

    internal class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(c => c.Id);
            Map(c => c.FirstName);
            Map(c => c.SecondName);
            Map(c => c.Patronymic);
            Map(c => c.TelephoneNumber);
            Map(c => c.Age);
            Map(c => c.Preferences);
            HasMany(c => c.CurrentRoutes).Check();
            HasMany(c => c.VisitedRoutes);
        }
    }
}
