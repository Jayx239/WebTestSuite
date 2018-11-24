using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebTestSuite.Test
{
    [TestClass]
    public class TestFactory
    {
        [TestMethod]
        public void TestGetTestSummary()
        {
            WebTestSuite.TestFactory testFactory = new WebTestSuite.TestFactory();
            Assert.IsInstanceOfType(testFactory.GetTestSummary(), typeof(WebTestSuite.TestSummary));
        }
    }
}
