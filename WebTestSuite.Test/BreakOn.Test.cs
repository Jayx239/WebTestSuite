using System.Collections.Generic;
using NUnit.Framework;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Exceptions;
using WebTestSuite.Suite;
using WebTestSuite.Test.SampleTestSuite;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebSuiteTest.Test
{
    [TestFixture]
    public class BreakOn
    {
        [Test]
        public void TestThrowEpicSuite()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.BreakOnFail = true;
            epicSuite.Suites[0].BreakOnFail = true;
            try
            {
                epicSuite.Execute();
            }
            catch (FailException failEx)
            {
                epicSuite.CleanUp();
                return;
            }
            Assert.IsTrue(false);
        }

        [Test]
        public void TestSuppressSuite()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.BreakOnFail = false;
            epicSuite.Suites[0].BreakOnFail = true;
            epicSuite.Suites.Add(new SampleSuitePass());
            epicSuite.Execute();
            Assert.IsTrue(epicSuite.Suites[0].Tests[0].TestResult.Executed);
            Assert.IsFalse(epicSuite.Suites[0].Tests[0].TestResult.Succeeded);
            Assert.IsFalse(epicSuite.Suites[0].Tests[1].TestResult.Executed);

            Assert.IsTrue(epicSuite.Suites[1].Tests[0].TestResult.Executed);
            Assert.IsTrue(epicSuite.Suites[1].Tests[0].TestResult.Succeeded);
            Assert.IsTrue(epicSuite.Suites[1].Tests[1].TestResult.Executed);
            Assert.IsTrue(epicSuite.Suites[1].Tests[1].TestResult.Succeeded);
        }
        [Test]
        public void TestSuppressTest()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.BreakOnFail = false;
            epicSuite.Suites.Add(new SampleSuitePass());
            epicSuite.Execute();
            Assert.IsTrue(epicSuite.Suites[0].Tests[0].TestResult.Executed);
            Assert.IsFalse(epicSuite.Suites[0].Tests[0].TestResult.Succeeded);
            Assert.IsTrue(epicSuite.Suites[0].Tests[1].TestResult.Executed);
            Assert.IsTrue(epicSuite.Suites[0].Tests[1].TestResult.Succeeded);

            Assert.IsTrue(epicSuite.Suites[1].Tests[0].TestResult.Executed);
            Assert.IsTrue(epicSuite.Suites[1].Tests[0].TestResult.Succeeded);
            Assert.IsTrue(epicSuite.Suites[1].Tests[1].TestResult.Executed);
            Assert.IsTrue(epicSuite.Suites[1].Tests[1].TestResult.Succeeded);
        }

        [Test]
        public void BreakOnEndTest()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.BreakOnFail = false;
            epicSuite.BreakOnEnd = true;
            epicSuite.Suites.Add(new SampleSuitePass());
            try
            {
                epicSuite.Execute();
            }
            catch (SuiteFailException sEx)
            {
                return;
            }
            Assert.IsTrue(false);
        }
        [Test]
        public void BreakOnEndSuccessfulTest()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.BreakOnFail = false;
            epicSuite.BreakOnEnd = true;
            epicSuite.CleanUp();
            epicSuite.Suites = new List<ITestSuite>() { new SampleSuitePass() };
            epicSuite.Execute();
            Assert.IsTrue(epicSuite.Sucessful);
            epicSuite.CleanUp();
        }
        [Test]
        public void TestNoBreakOnFailTest()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.BreakOnFail = false;
            epicSuite.BreakOnEnd = false;
            epicSuite.Suites[0].BreakOnFail = false;
            epicSuite.CleanUp();

        }
    }
}
