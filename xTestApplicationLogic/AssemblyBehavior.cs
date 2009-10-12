using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Introspectator.ApplicationLogic;

namespace xTestApplicationLogic
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class AssemblyBehavior
    {
        public AssemblyBehavior()
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

        [TestMethod]
        public void GivenAnAssemblyWithNoTypesItsTypeCountShouldBeZero()
        {
            MockRepository mocks = new MockRepository();
            IAssemblyInfo mockAssembly = mocks.DynamicMock<IAssemblyInfo>();
            IAssemblyLoader loader = mocks.DynamicMock<IAssemblyLoader>();
            loader.Expect(l => l.LoadFrom(null)).IgnoreArguments().Return(mockAssembly);
            mockAssembly.Expect(a => a.Types).Return(new List<ITypeInfo> { });
            mocks.ReplayAll();
            
            IAssemblyInfo assembly = loader.LoadFrom(@"C:\Location\LocationWhatever.dll");
            int count = assembly.Types.Count;

            mocks.VerifyAll();
            Assert.AreEqual(0, count);
            
        }

        //If a type is associated with another type though a field or property reference then the type is external type dependent 
        [TestMethod]
        public void Given_a_type_with_all_private_methods_should_be_able_to_see_it_is_private()
        {
            //MockRepository mocks = new MockRepository();
            //IAssembly assembly = mocks.DynamicMock<IAssembly>();
            //assembly.Expect<
        }


        [TestMethod]
        public void Given_a_type_with_all_public_methods_should_be_able_to_see_it_is_public()
        {

        }

        //[TestMethod]
        //public vod Given

        //If a method within a type through its parameters is assoicated with another type then the type is external type dependent
        
        //If a method within a type through its return type is associated with another type then the type is external type dependent

        //If a method within a type through its body is associated with another type then the type is external type dependent

        //If a parameter within a type through its body is associated with another type then the type is external type dependent

        //If a field within a type through its declaration is associated with another type then the type is external type depenedent


        //So I know if a given type is external dependent:
        //Need to know create a matrix of dependencies for the thing 

        //List all types in the assembly and then list all the dependency count of the assembly

    }
}
