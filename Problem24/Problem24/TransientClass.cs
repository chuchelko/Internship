namespace Problem24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class TransientClass
    {
        Guid guid = Guid.NewGuid();

        public string GetId() => guid.ToString();
    }
}
