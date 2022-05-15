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

        public ISession GetSession()
        {
            return CreateSessionFactory().OpenSession();
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
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Worker>())
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
