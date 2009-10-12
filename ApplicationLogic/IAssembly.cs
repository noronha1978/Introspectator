using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Introspectator.ApplicationLogic
{
    public interface IAssemblyInfo
    {
        string Name { get; set; }
        IList<ITypeInfo> Types { get; set; }
    }


    public class AssemblyInfo:IAssemblyInfo
    {

        #region IAssemblyInfo Members

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private IList<ITypeInfo> _types;
        public IList<ITypeInfo> Types
        {
            get
            {
                return _types;
            }
            set
            {
                _types = value;
            }
        }

        #endregion
    }


    public interface ITypeInfo
    {

    }

    public class TypeInfo:ITypeInfo
    {

    }

    public interface IMethodInfo
    {

    }

    public class MethodInfo
    {

    }

    public interface IPropertyInfo
    {

    }

    public class PropertyInfo
    {

    }
}
