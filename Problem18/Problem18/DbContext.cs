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

    using Problem18;

    internal class DbContext
    {
        private static MyInterceptor interceptor = new MyInterceptor();
        public ISession GetSession()
        {
            return CreateSessionFactory().OpenSession();
        }

        private ISessionBuilder CreateSessionFactory()
        {
            return Fluently
                .Configure()
                .Database(
                        PostgreSQLConfiguration.PostgreSQL82.ConnectionString(c =>
                            c.Host("localhost")
                            .Port(5432)
                            .Database("userdb")
                            .Username("postgres")
                            .Password("password")).AdoNetBatchSize(5))
                .Cache(cache => 
                    cache.UseQueryCache()
                    .UseMinimalPuts())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Worker>())
                .ExposeConfiguration(TreatConfiguration)
                //.ExposeConfiguration(c => 
                //    c.SetProperty(@"nhibernate-logger", @"NHibernate.NLogLoggerFactory, NHibernate.NLog"))
                .BuildSessionFactory()
                .WithOptions()
                .Interceptor(new MyInterceptor());
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
