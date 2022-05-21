namespace Problem24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Castle.Facilities.Startable;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    internal class CastleClassInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<StartableFacility>();

            container.Register(

                Component.For<TransientClass>().ImplementedBy<TransientClass>().LifestyleTransient(),

                Component.For<ICastleClass>()
                    .ImplementedBy<CastleClass>()
                    .LifestyleSingleton(),

                Component.For<IConstructorInjectionClass>()
                    .ImplementedBy<ConstructorInjectionClass>()
                    .StartUsingMethod(@class => @class.Start),

                Component.For<IPropertyInjectionClass>()
                    .ImplementedBy<PropertyInjectionClass>()
                    .StartUsingMethod(@class => @class.Start)



                ) ;


        }
    }
}
