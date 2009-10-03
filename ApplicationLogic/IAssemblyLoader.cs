using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Introspectator.ApplicationLogic
{
    public interface IAssemblyLoader
    {
        IAssembly LoadFrom(string p);
    }
}
