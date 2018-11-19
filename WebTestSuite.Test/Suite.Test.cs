using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Suite;

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
            ITestSuite sampleSuite = epicSuite.Suites[0];
            Assert.IsTrue(epicSuite.ShowStackTrace);
            Assert.IsTrue(sampleSuite.ShowStackTrace);
            epicSuite.ShowStackTrace = false;
            Assert.IsFalse(epicSuite.ShowStackTrace);
            Assert.IsFalse(sampleSuite.ShowStackTrace);
            epicSuite.ShowStackTrace = true;
            Assert.IsTrue(epicSuite.ShowStackTrace);
            Assert.IsTrue(sampleSuite.ShowStackTrace);
            Assert.IsFalse(sampleSuite.Tests[0].Sucessful);
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
        [TestMethod]
        public void TestPrintSummaryString()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.PrintSummaryString();
            epicSuite.CleanUp();
            SampleSuite sampleSuite = new SampleSuite();
            sampleSuite.PrintSummaryString();
            sampleSuite.CleanUp();
        }
        [TestMethod]
        public void TestPrintPassFailSummary()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.PrintPassFailSummary();
            epicSuite.CleanUp();
            SampleSuite sampleSuite = new SampleSuite();
            sampleSuite.PrintPassFailSummary();
            sampleSuite.CleanUp();
        }
        [TestMethod]
        public void TestSuiteConstructors()
        {
            ITestSummary testSummary = new WebTestSuite.TestSummary();
            TestSuite testSuite1 = new WebTestSuite.Suite.TestSuite(testSummary);
            Assert.AreEqual(testSummary, testSuite1.Summary);

            WebTestSuite.Suite.SuiteDescription suiteDescription = new WebTestSuite.Suite.SuiteDescription() { Client="client", SuiteName="SuiteName"};
            TestSuite testSuite2 = new WebTestSuite.Suite.TestSuite(testSummary, suiteDescription);
            Assert.AreEqual(testSummary, testSuite2.Summary);
            Assert.AreEqual(suiteDescription, testSuite2.SuiteDescription);

            TestSuite testSuite3 = new WebTestSuite.Suite.TestSuite(suiteDescription);
            Assert.AreEqual(suiteDescription, testSuite3.SuiteDescription);

            testSuite1.Summary = testSummary;
            Assert.AreEqual(testSummary, testSuite1.Summary);
        }

    }
}
