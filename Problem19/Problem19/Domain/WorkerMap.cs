namespace Problem16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentNHibernate.Mapping;

    internal class WorkerMap : ClassMap<Worker>
    {
        public WorkerMap()
        {
            Id(w => w.Id)
                .GeneratedBy.Guid()
                .Column("id");
            Map(w => w.Name)
                .Column("name");
            Map(w => w.Date)
                .Column("date");
            Map(w => w.Salary)
                .Column("salary");
            Map(w => w.Age)
                .Column("age");
            Map(w => w.Login)
                .Column("login");
            Table("workers");
        }
    }
}
