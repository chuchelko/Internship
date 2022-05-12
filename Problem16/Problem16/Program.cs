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
            IList<User> users = db.FillAndGetUsers(new List<User> {
            new User { FirstName = "Maxim", Email = "maximemail", SecondName = "Shafiullin"},
            new User { FirstName = "Marat", Email= "maratemail"}});

            foreach (var user in users)
            {
                Console.WriteLine(user.FirstName + ' ' + user.Email);
            }
        }

    }    
}
