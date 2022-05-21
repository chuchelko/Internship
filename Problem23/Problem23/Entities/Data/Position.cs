namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Position
    {
        /* Id
	Name
	PrepaymentDay
	SalaryMainPartDay
	Responsibilities */
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int PrepaymentDay { get; set; }
        public virtual int SalaryMainPartDay { get; set; }
        public virtual string Responsibilities { get; set; }

    }
}
