namespace Problem16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Worker
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual decimal Salary { get; set; }
        public virtual int Age { get; set; }
        public virtual DateTime Date { get; set; }
       
    }
}
