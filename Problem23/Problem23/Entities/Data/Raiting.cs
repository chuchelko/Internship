namespace Problem23.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Raiting
    {
        public virtual Guid Id  { get; set; }
        public virtual int Value { get; set; }
        public virtual Route Route { get; set; }
    }
}
