using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Exceptions;
using WebTestSuite.Test.SampleTestSuite;

namespace WebTestSuite.Test
{
    [TestClass]
    public class TestSummary
    {
        [TestMethod]
        public void TestPrintStackTrace()
        {
            SampleEpicSuite epicScuite = new SampleEpicSuite();
            epicScuite.ShowStackTrace = true;
            epicScuite.BreakOnFail = false;
            epicScuite.BreakOnEnd = true;
            epicScuite.Suites.Add(new SampleSuitePass());
            try
            {
                epicScuite.Execute();
            }
            catch (SuiteFailException sEx)
            {
                Assert.IsFalse(epicScuite.Sucessful);
                return;
            }
            Assert.IsTrue(false);
        
        }
    }
}
