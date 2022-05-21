namespace Problem24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ConstructorInjectionClass : IConstructorInjectionClass
    {
        private ICastleClass castleClass;
        private TransientClass transientClass;

        public ConstructorInjectionClass(ICastleClass castle, TransientClass transient)
        {
            castleClass = castle;
            transientClass = transient;
        }

        public void Start()
        {
            Console.WriteLine($"Constructor Injection {castleClass.GetName()}, transient class guid = {transientClass.GetId()}");
        }
    }
}
