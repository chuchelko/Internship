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

            List<User> users = new List<User>();
            for(int i = 0; i < 2; i++)
            {
                User user = new User()
                {
                    FirstName = "name" + i,
                    Email = "email",
                    Location = new Location()
                    {
                        Country = "country " + i,
                        City = "Elabuga",
                        Adress = "Adress"
                    }
                };
                user.Add(new Post() { CreationTime = DateTime.Now, Text = "PostText1 " + i });
                user.Add(new Post() { CreationTime = DateTime.Now, Text = "PostText2 " + i});
                users.Add(user);
            };
            

            IList<User> recievedUsers = db.FillAndGetUsers(users);

            foreach (var user in recievedUsers)
            {
                Console.WriteLine(user.FirstName + ' ' + user.Email + ' ' + user.Location.Country);
                if(user.Posts != null)
                    foreach(var post in user.Posts)
                        Console.WriteLine("\t" + post.Text + " Created at " + post.CreationTime);
            }
        }

    }    
}
