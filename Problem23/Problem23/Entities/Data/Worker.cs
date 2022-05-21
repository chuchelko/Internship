namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Worker
    {
		/*Id
	FirstName
	SecondName
	ThirdName
	TelephoneNumber
	Age
	DoesWorkNow
	List<Route> RoutesCompleted
	MonthSalary
	HiringDate
	PositionID ref (Position)*/
		public virtual Guid Id { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string SecondName { get; set; }
		public virtual string Patronymic { get; set; }
		public virtual string TelephoneNumber { get; set; }
		public virtual int Age { get; set; }
		public virtual bool DoesWorkNow { get; set; }
		public virtual List<Route> RoutesCompleted { get; set; }
		public virtual decimal MonthSalary { get; set; }
		public virtual DateTime HiringDate { get; set; }
		public virtual Position Position { get; set; }
	}
}
