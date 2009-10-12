using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Introspectator.ApplicationLogic
{
    public class AssemblyLoader : IAssemblyLoader
    {
        public IAssemblyInfo LoadFrom(string assemblyName)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyName);
            IAssemblyInfo assemblyInfo = new AssemblyInfo();
            assemblyInfo.Name = assembly.FullName;
            assemblyInfo.Types = LoadTypes(assembly);
            return assemblyInfo;
        }

        private IList<ITypeInfo> LoadTypes(Assembly assembly)
        {
            IList<ITypeInfo> types = new List<ITypeInfo>();
            Type[] netTypes = assembly.GetTypes();
            foreach (Type netType in netTypes)
            {
                ITypeInfo type = new TypeInfo();
                //netType.Name;
                //netType.Namespace;
                //netType.
            }
            return types;
        }
    }
}
