using ImifiedCHashLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ImifiedCHashLibUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ImifiedFacadeTest and is intended
    ///to contain all ImifiedFacadeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ImifiedFacadeTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAllUsers
        ///</summary>
        [TestMethod()]
        public void GetAllUsersTest()
        {
            string NetworkName = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImifiedFacade.GetAllUsers(NetworkName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserIdByUserName
        ///</summary>
        [TestMethod()]
        public void GetUserIdByUserNameTest()
        {
            string UserName = "brijraj.singh@mscriber.com"; // TODO: Initialize to an appropriate value
            string NetworkName = string.Empty; // TODO: Initialize to an appropriate value
            string expected = "37BB44D4-4027-41CD-B8AF9605F1D8B094"; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImifiedFacade.GetUserIdByUserName(UserName, NetworkName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SendMessage
        ///</summary>
        [TestMethod()]
        public void SendMessageTest()
        {
            string UserKey = "37BB44D4-4027-41CD-B8AF9605F1D8B094"; // TODO: Initialize to an appropriate value
            string MessageText = "hello brij, good morning"; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ImifiedFacade.SendMessage(UserKey, MessageText);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
