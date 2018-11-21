using System;
using NUnit.Framework;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Exceptions;
using WebTestSuite.Test.SampleTestSuite;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebTestSuite.Test
{
    [TestFixture]
    public class TestSummary
    {
        [Test]
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
