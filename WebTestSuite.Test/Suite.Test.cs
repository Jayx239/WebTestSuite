using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSuiteTest.Test.SampleTestSuite;

namespace WebTestSuite.Test
{
    [TestClass]
    public class Suite
    {
        [TestMethod]
        public void TestNameDescriptionConstructor()
        {
            //WebTestSuite.Suite.TestSuite testSuite = new WebTestSuite.Suite.TestSuite();

        }

        [TestMethod]
        public void TestShowStackTrace()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.ShowStackTrace = false;
            Assert.IsFalse(epicSuite.ShowStackTrace);
            epicSuite.ShowStackTrace = true;
            Assert.IsTrue(epicSuite.ShowStackTrace);
            epicSuite.CleanUp();
        }
        [TestMethod]
        public void BreakOnFail()
        {
            SampleTestSuite.SampleSuitePass testSuite = new SampleTestSuite.SampleSuitePass();
            testSuite.BreakOnFail = false;
            Assert.IsFalse(testSuite.BreakOnFail);
            testSuite.BreakOnFail = true;
            Assert.IsTrue(testSuite.BreakOnFail);
            testSuite.CleanUp();
        }
    }
}
