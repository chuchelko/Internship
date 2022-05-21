namespace Problem24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PropertyInjectionClass : IPropertyInjectionClass
    {
        public ICastleClass CastleClass { get; set; }
        public TransientClass TransientClass { get; set; }

        public void Start()
        {
            Console.WriteLine($"Property Injection {CastleClass.GetName()}, transient class guid = {TransientClass.GetId()}");
        }
    }
}
