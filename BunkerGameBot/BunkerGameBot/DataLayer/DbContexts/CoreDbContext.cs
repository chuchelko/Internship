#define IN_MEMORY
namespace BunkerGameBot.DataLayer.DbContexts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BunkerGameBot.DataLayer.Entities;

    using Microsoft.EntityFrameworkCore;

    internal class CoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Characteristics> Characteristics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Theme> Theme { get; set; }

        public CoreDbContext()
        {
            base.Database.EnsureDeleted();
            base.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if IN_MEMORY
            optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("bunkerdb");
#else
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(Constants.ConnectionString);
#endif

            base.OnConfiguring(optionsBuilder);
        }

    }
}
