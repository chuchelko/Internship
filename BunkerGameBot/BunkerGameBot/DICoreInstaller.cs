namespace BunkerGameBot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BunkerGameBot.DataLayer.DbContexts;
    using BunkerGameBot.DataLayer.Repositories;
    using BunkerGameBot.LogicLayer;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    internal class DICoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore configurationStore)
        {
            container.Register(
                Component.For<CoreDbContext>().ImplementedBy<CoreDbContext>().LifestyleSingleton(),
                Component.For<IRepository>().ImplementedBy<CoreRepository>().LifestyleSingleton(),
                Component.For<UpdateHandler>().ImplementedBy<UpdateHandler>().LifestyleTransient(),
                Component.For<ErrorHandler>().ImplementedBy<ErrorHandler>().LifestyleTransient()
                );
        }
    }
}
