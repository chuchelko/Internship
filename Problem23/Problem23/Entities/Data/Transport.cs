namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    
    internal class Transport
    {
        /* Id
	Type
	Speed
	Worker - водитель
	PlacesCount */
        public virtual Guid Id { get; set; }
        public virtual string TransportType { get; set; }
        public virtual int Speed { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual int PlacesCount { get; set; }
        
    }
}
