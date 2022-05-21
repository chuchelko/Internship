namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal enum ImportantRoutePointType
    {
        Stay,
        Halt,
        OvernightStay
    }
    internal class ImportantRoutePoint
    {
        /*Id
	Type = {стоянка, привал, ночлег}
	Duration
	Description
	PriceInRoubles*/
        public virtual Guid Id { get; set; }
        public virtual ImportantRoutePointType Type { get; set; }
        public virtual Route Route { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal PriceInRoubles { get; set; }
    }
}
