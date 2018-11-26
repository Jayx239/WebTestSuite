using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebTestSuite.Test
{
    [TestClass]
    public class SuiteDescription
    {
        [TestMethod]
        public void TestMethod1()
        {
            WebTestSuite.Suite.SuiteDescription suiteDescription = new WebTestSuite.Suite.SuiteDescription("Suite name", "Client");
            Assert.AreEqual(suiteDescription.SuiteName, "Suite name");
            Assert.AreEqual(suiteDescription.Description, "Client");
        }
    }
}
