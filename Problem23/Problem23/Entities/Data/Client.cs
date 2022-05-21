namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NHibernate.Mapping.Attributes;

    internal class Client
    {
        /*Id
	FirstName
	SecondName
	ThirdName
	TelephoneNumber
	Age
	List<Route> VisitedRoutes
	List<Route> CurrentRoutes
	Preferences*/
        [Id]
        [Generator(Class = "Guid")]
        public virtual Guid Id { get; set; }

        [Property]
        public virtual string FirstName { get; set; }
        
        [Property]
        public virtual string SecondName { get; set; }

        [Property]
        public virtual string Patronymic { get; set; }

        [Property]
        public virtual string TelephoneNumber { get; set; }
        
        [Property]
        public virtual int Age { get; set; }

        [Property]
        public virtual string Preferences { get; set; }

        public virtual List<Route> VisitedRoutes { get; set; } = new List<Route>();
        public virtual List<Route> CurrentRoutes { get; set; } = new List<Route>();
        
    }
}
