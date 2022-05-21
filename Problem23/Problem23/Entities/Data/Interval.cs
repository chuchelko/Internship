namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Interval
    {
        /*Id
	LengthInKm
	Duration
	Transport
	List<Worker> */
        public virtual Guid Id { get; set; }
        public virtual double LengthInKm { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual Route Route { get; set; }
        public virtual Transport Transport { get; set; }
        public virtual List<Worker> Workers { get; set; }
    }
}
