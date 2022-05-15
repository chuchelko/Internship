namespace Problem16
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate.Tool.hbm2ddl;

    internal class Program
    {
        static void Main(string[] args)
        {
            DbContext db = new DbContext();

            using var session = db.GetSession();
            using var tx = session.BeginTransaction();

            object id = session.Save(new Worker() { Age = 20, Name = "worker1" });


            List<Worker> workers = session.Query<Worker>().Where(x => x.Name == "worker1").ToList();

            workers[0].Name = "worker updated";

            session.Update(workers[0]);

            tx.Commit();
        }

    }    
}
