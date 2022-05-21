namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal enum RouteType
    {
        Hike,
        Excursion
    }
    internal class Route
    {
        /*
         * Id
	Type (походный, экскурсионный)
	ShortName
	LengthInKm
	List<Worker>
	TimeInRoute
	List<ImportantRoutePoint>
	List<Interval>
	Description*/
        
        public virtual Guid Id { get; set; }
        public virtual RouteType RouteType { get; set; }
        public virtual string ShortName { get; set; }
        //public virtual double LengthInKm { get; set; }
        public virtual List<Worker> WorkersInRoute { get; set; } = new List<Worker>();
        //public virtual TimeSpan TimeInRoute { get; set; }
        public virtual List<ImportantRoutePoint> ImportantRoutePoints { get; set;} = new List<ImportantRoutePoint>();
        public virtual List<Interval> Intervals { get; set; } = new List<Interval>();
        public virtual List<Raiting> Raitings { get; set; } = new List<Raiting>();
        public virtual string Description { get; set; }
    }
    
}
