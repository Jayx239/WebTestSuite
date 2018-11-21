using System;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebTestSuite.Test
{
    [TestFixture]
    public class BaseTestTests
    {
        [Test]
        public void SummaryConstructor()
        {
            ITestResult testResult = new TestResult();
            WebTestSuite.Test.BaseTest baseTest = new WebTestSuite.Test.BaseTest(testResult);
            Assert.AreEqual(testResult, baseTest.TestResult);
        }
        [Test]
        public void TestSetUp()
        {
            WebTestSuite.Test.BaseTest baseTest = new WebTestSuite.Test.BaseTest();
            baseTest.SetUp();
        }
    }
}
