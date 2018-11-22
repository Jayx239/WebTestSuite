using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Suite;
using WebTestSuite.Test.SampleTestSuite;

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
        [TestMethod]
        public void TestFailGracefully()
        {
            FailGracefulTest test = new FailGracefulTest();
            test.Execute();
            Assert.IsTrue(test.TestResult.Executed);
            Assert.IsFalse(test.Sucessful);
        }

        [TestMethod]
        public void TestSuiteCleanupException()
        {
            EpicSuite epic = new EpicSuite();
            TestSuite suite = new SuiteCleanupException();
            epic.Suites.Add(suite);
            //suite.Tests.Add(new ExceptionTest());
            suite.Tests.Add(new SampleTestPass(new ChromeDriver()));
            suite.BreakOnFail = true;
            epic.Execute();
        }
    }
}
