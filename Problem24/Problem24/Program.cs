namespace Problem24
{
    using System;
    using System.Reflection;

    using Castle.Windsor;
    using Castle.Windsor.Installer;

    internal class Program
    {
        static void Main(string[] args)
        {
            using var container = new WindsorContainer();

            container.Install(new CastleClassInstaller());
            var castle = container.Resolve<ICastleClass>();


            var constructorInjectionClass = container.Resolve<IConstructorInjectionClass>();
            var propertyInjectionClass = container.Resolve<IPropertyInjectionClass>();

        }
    }
}
