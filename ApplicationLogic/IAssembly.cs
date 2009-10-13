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
        System.Collections.Generic.IList<IFieldInfo> Fields { get; set; }
        System.Collections.Generic.IList<IEventInfo> Events { get; set; }
        System.Collections.Generic.IList<IPropertyInfo> Properties { get; set; }
        System.Collections.Generic.IList<IMethodInfo> Methods { get; set; }
        string Namespace { get; set; }
        string Name { get; set; }

    }

    public class TypeInfo:ITypeInfo
    {
        private IList<IFieldInfo> _fields;
        private IList<IEventInfo> _events;
        private IList<IPropertyInfo> _properties;
        private IList<IMethodInfo> _methods;
        private string _namespace;
        private string _name;
        
        #region ITypeInfo Members

        public IList<IFieldInfo> Fields
        {
            get
            {
                return _fields;
            }
            set
            {
                _fields = value;
            }
        }

        public IList<IEventInfo> Events
        {
            get
            {
                return _events;
            }
            set
            {
                _events = value;
            }
        }

        public IList<IPropertyInfo> Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

        public IList<IMethodInfo> Methods
        {
            get
            {
                return _methods;
            }
            set
            {
                _methods = value;
            }
        }

        public string Namespace
        {
            get
            {
                return _namespace;
            }
            set
            {
                _namespace = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }

    public class AbstractClass : TypeInfo
    {

    }

    public class Class : TypeInfo
    {

    }

    public class Interface : TypeInfo
    {

    }

    public class Enumeration : TypeInfo
    {

    }

    public interface IMethodInfo
    {
        string Name { get; set; }

    }

    public class MethodInfo:IMethodInfo
    {
        private string _name;
        #region IMethodInfo Members

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }

    public interface IPropertyInfo
    {
        string Name { get; set; }

    }

    public class PropertyInfo:IPropertyInfo
    {
        private string _name;
        #region IPropertyInfo Members

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }

    public interface IEventInfo
    {
        string Name { get; set; }
    }

    public class EventInfo:IEventInfo
    {
        private string _name;
        #region IEventInfo Members

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }

    public interface IFieldInfo
    {
        string Name { get; set; }
    }

    public class FieldInfo : IFieldInfo
    {
        private string _name;
        #region IEventInfo Members

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        #endregion
    }
}
