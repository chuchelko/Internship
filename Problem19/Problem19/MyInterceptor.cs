namespace Problem18
{
    using System;
    using System.Diagnostics;


    using NHibernate;
    using NHibernate.SqlCommand;

    using NLog;

    using Problem16;

    internal class MyInterceptor : EmptyInterceptor
    {

        public override SqlString OnPrepareStatement(SqlString sql)
        {

            Logger logger = LogManager.GetLogger("NHibernate.SQL");

            logger.Debug(sql.ToString());

            return base.OnPrepareStatement(sql);
        }
    }
}
