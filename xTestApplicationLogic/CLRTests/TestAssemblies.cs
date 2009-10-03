using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace xTestApplicationLogic.CLRTests
{
    /// <summary>
    /// Summary description for TestAssemblies
    /// </summary>
    [TestClass]
    public class TestAssemblies
    {
        public TestAssemblies()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private Assembly assembly;

        [TestInitialize]
        public void Initialize()
        {
            string assemblyPath = @"C:\ArunsProjects\Introspectator\zTestSampleAssembly\bin\Debug\Introspectator.zTestSampleAssembly.dll";
            assembly = Assembly.LoadFrom(assemblyPath);
        }

        [TestMethod]
        public void TestLoadingAnAssembly()
        {
            Assert.IsNotNull(assembly.FullName);
        }

        [TestMethod]
        public void TestLoadingAllTypesFromAssembly()
        {
            Type[] t = assembly.GetTypes();
            Console.WriteLine(t.Length);
            Assert.IsTrue(t.Length >= 0);
        }

        public void TestLoadingAllMethodsInAllTypesFromAssembly()
        {
            Type[] t = assembly.GetTypes();

            MethodInfo[] methods = t[0].GetMethods();
            //methods[0].ReturnType
            MethodBody mb = methods[0].GetMethodBody();
            IList<LocalVariableInfo> listLocal = mb.LocalVariables;
            Type typ = listLocal[0].LocalType;

            

            //typ.
        }
    }
}
