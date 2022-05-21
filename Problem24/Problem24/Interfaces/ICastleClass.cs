namespace Problem24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface ICastleClass
    {
        string GetName();

        Guid guid { get; }
    }
}
