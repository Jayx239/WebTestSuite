using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebTestSuite.Test
{
    [TestClass]
    public class BaseTestTests
    {
        [TestMethod]
        public void SummaryConstructor()
        {
            ITestResult testResult = new TestResult();
            WebTestSuite.Test.BaseTest baseTest = new WebTestSuite.Test.BaseTest(testResult);
            Assert.AreEqual(testResult, baseTest.TestResult);
        }
        [TestMethod]
        public void TestSetUp()
        {
            WebTestSuite.Test.BaseTest baseTest = new WebTestSuite.Test.BaseTest();
            baseTest.SetUp();
        }
    }
}
