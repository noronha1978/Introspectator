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
                ITypeInfo typeInfo = CreateNewTypeInfo(netType);

                typeInfo.Methods = GetMethodsFor(netType);
                typeInfo.Properties = GetPropertiesFor(netType);
                typeInfo.Events = GetEventsFor(netType);
                typeInfo.Fields = GetFieldsFor(netType);
            }
            return types;
        }

        private IList<IFieldInfo> GetFieldsFor(Type netType)
        {
            IList<IFieldInfo> fields = new List<IFieldInfo>();
            System.Reflection.FieldInfo[] netFields = netType.GetFields(BindingFlags.Public | BindingFlags.NonPublic);
            foreach (System.Reflection.FieldInfo netField in netFields)
            {
                IFieldInfo fieldInfo = new FieldInfo();
                fieldInfo.Name = netField.Name;
                fields.Add(fieldInfo);
            }
            return fields;
        }

        private IList<IEventInfo> GetEventsFor(Type netType)
        {
            IList<IEventInfo> events = new List<IEventInfo>();
            System.Reflection.EventInfo[] netEvents = netType.GetEvents(BindingFlags.Public | BindingFlags.NonPublic);
            foreach (System.Reflection.EventInfo netEvent in netEvents)
            {
                IEventInfo eventInfo = new EventInfo();
                eventInfo.Name = netEvent.Name;
                events.Add(eventInfo);
            }
            return events;
        }

        private IList<IPropertyInfo> GetPropertiesFor(Type netType)
        {
            IList<IPropertyInfo> properties = new List<IPropertyInfo>();
            System.Reflection.PropertyInfo[] netProperties = netType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic);
            foreach (System.Reflection.PropertyInfo netProperty in netProperties)
            {
                IPropertyInfo propertyInfo = new PropertyInfo();
                propertyInfo.Name = netProperty.Name;
                properties.Add(propertyInfo);
            }
            return properties;
        }

        private IList<IMethodInfo> GetMethodsFor(Type netType)
        {
            IList<IMethodInfo> methods = new List<IMethodInfo>();
            System.Reflection.MethodInfo[] netMethods = netType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic);
            foreach (System.Reflection.MethodInfo netMethod in netMethods)
            {
                IMethodInfo methodInfo = new MethodInfo();
                methodInfo.Name = netMethod.Name;
                methods.Add(methodInfo);
            }
            return methods;
        }


        private ITypeInfo CreateNewTypeInfo(Type netType)
        {
            ITypeInfo type = null;
            if (netType.IsAbstract)
            {
                type = new AbstractClass();
            }
            else if (netType.IsClass)
            {
                type = new Class();
            }
            else if (netType.IsInterface)
            {
                type = new Interface();
            }
            else if (netType.IsEnum)
            {
                type = new Enumeration();
            }
            type.Name = netType.Name;
            type.Namespace = netType.Namespace;

            return type;
        }
    }
}
