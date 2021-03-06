namespace Problem16
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    internal class DbContext
    {

        public IList<User> FillAndGetUsers(List<User> users)
        {
            var sessionFactory = CreateSessionFactory();

            using var session = sessionFactory.OpenSession();
            using var trans = session.BeginTransaction();

            
            session.Query<User>().ToList().ForEach(u => session.Delete(u));

            session.SetBatchSize(5);

            int i = 0;
            if (users != null)
                foreach (var user in users)
                {
                    if (i == 5)
                    {

                        i = 0;
                    }
                    session.SaveOrUpdate(user);
                    i++;
                }

            trans.Commit();


            using (session.BeginTransaction())
            {
                var items = session.CreateCriteria<User>().List<User>();
                var items2 = session.Query<User>().ToList();
                return items2;
            }
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently
                .Configure()
                .Database(
                        PostgreSQLConfiguration.PostgreSQL82.ConnectionString(c =>
                            c.Host("localhost")
                            .Port(5432)
                            .Database("userdb")
                            .Username("postgres")
                            .Password("password")).ShowSql().AdoNetBatchSize(5))
                .Cache(cache => 
                    cache.UseQueryCache()
                    .UseMinimalPuts())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                .ExposeConfiguration(TreatConfiguration)
                .BuildSessionFactory();
        }

        private static void TreatConfiguration(Configuration configuration)
        {
            Action<string> updateExport = x =>
            {
                using var file = new FileStream(@"update.sql", FileMode.Append, FileAccess.Write);
                using var sw = new StreamWriter(file);
                sw.Write(x);
                sw.Close();
            };

            var update = new SchemaUpdate(configuration);
            update.Execute(updateExport, true);
        }
    }
}
