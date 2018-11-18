using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Exceptions;
using WebTestSuite.Test.SampleTestSuite;

namespace WebSuiteTest.Test
{
    [TestClass]
    public class BreakOn
    {
        [TestMethod]
        public void TestThrowEpicSuite()
        {
            SampleEpicSuite epicScuite = new SampleEpicSuite();
            epicScuite.BreakOnFail = true;
            epicScuite.Suites[0].BreakOnFail = true;
            try
            {
                epicScuite.Execute();
            }
            catch (FailException failEx)
            {
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestSuppressSuite()
        {
            SampleEpicSuite epicScuite = new SampleEpicSuite();
            epicScuite.BreakOnFail = false;
            epicScuite.Suites[0].BreakOnFail = true;
            epicScuite.Suites.Add(new SampleSuitePass());
            epicScuite.Execute();
            Assert.IsTrue(epicScuite.Suites[0].Tests[0].TestResult.Executed);
            Assert.IsFalse(epicScuite.Suites[0].Tests[0].TestResult.Succeeded);
            Assert.IsFalse(epicScuite.Suites[0].Tests[1].TestResult.Executed);

            Assert.IsTrue(epicScuite.Suites[1].Tests[0].TestResult.Executed);
            Assert.IsTrue(epicScuite.Suites[1].Tests[0].TestResult.Succeeded);
            Assert.IsTrue(epicScuite.Suites[1].Tests[1].TestResult.Executed);
            Assert.IsTrue(epicScuite.Suites[1].Tests[1].TestResult.Succeeded);
            System.Console.Write("Complete");
        }
        [TestMethod]
        public void TestSuppressTest()
        {
            SampleEpicSuite epicScuite = new SampleEpicSuite();
            epicScuite.BreakOnFail = false;
            epicScuite.Suites.Add(new SampleSuitePass());
            epicScuite.Execute();
            Assert.IsTrue(epicScuite.Suites[0].Tests[0].TestResult.Executed);
            Assert.IsFalse(epicScuite.Suites[0].Tests[0].TestResult.Succeeded);
            Assert.IsTrue(epicScuite.Suites[0].Tests[1].TestResult.Executed);
            Assert.IsTrue(epicScuite.Suites[0].Tests[1].TestResult.Succeeded);

            Assert.IsTrue(epicScuite.Suites[1].Tests[0].TestResult.Executed);
            Assert.IsTrue(epicScuite.Suites[1].Tests[0].TestResult.Succeeded);
            Assert.IsTrue(epicScuite.Suites[1].Tests[1].TestResult.Executed);
            Assert.IsTrue(epicScuite.Suites[1].Tests[1].TestResult.Succeeded);
        }

        [TestMethod]
        public void BreakOnEndTest()
        {
            SampleEpicSuite epicScuite = new SampleEpicSuite();
            epicScuite.BreakOnFail = false;
            epicScuite.BreakOnEnd = true;
            epicScuite.Suites.Add(new SampleSuitePass());
            try
            {
                epicScuite.Execute();
            }
            catch (SuiteFailException sEx)
            {
                return;
            }
            Assert.IsTrue(false);
        }
    }
}
