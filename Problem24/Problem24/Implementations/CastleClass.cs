namespace Problem24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class CastleClass : ICastleClass
    {
        public Guid guid { get; } = Guid.NewGuid();
        public string GetName()
        {
            return guid.ToString() + " Injected Castle";
        }
    }
}
