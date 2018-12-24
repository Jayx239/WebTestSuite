using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Suite;
using WebTestSuite.Test.SampleTestSuite;

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
            epicSuite.PrintSummary();
            epicSuite.CleanUp();
            SampleSuite sampleSuite = new SampleSuite();
            sampleSuite.PrintSummary();
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

            WebTestSuite.Suite.SuiteDescription suiteDescription = new WebTestSuite.Suite.SuiteDescription() { Description="client", SuiteName="SuiteName"};
            TestSuite testSuite2 = new WebTestSuite.Suite.TestSuite(testSummary, suiteDescription);
            Assert.AreEqual(testSummary, testSuite2.Summary);
            Assert.AreEqual(suiteDescription, testSuite2.SuiteDescription);

            TestSuite testSuite3 = new WebTestSuite.Suite.TestSuite(suiteDescription);
            Assert.AreEqual(suiteDescription, testSuite3.SuiteDescription);

            testSuite1.Summary = testSummary;
            Assert.AreEqual(testSummary, testSuite1.Summary);
        }
        [TestMethod]
        public void TestSuiteException()
        {
            ExceptionTest test = new ExceptionTest();
            test.Execute();
            Assert.IsTrue(test.TestResult.Executed);
            Assert.IsFalse(test.TestResult.Succeeded);
            ExceptionTest test2 = new ExceptionTest();
            try
            {
                test2.BreakOnFail = true;
                test2.Execute();
            }
            catch(Exception e)
            {
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestDefaultWebTestConstructor()
        {
            WebSuite webTest = new WebSuite();
            Assert.IsNull(webTest.WebDriver);
        }
        [TestMethod]
        public void TestDriverConstructor()
        {
            WebSuite webTestSuite = new WebSuite(new ChromeDriver());
            Assert.IsNotNull(webTestSuite.WebDriver);
            WebTest noDriverTest = new WebTest();
            webTestSuite.AddTest(noDriverTest);
            Assert.IsTrue(((WebTest)webTestSuite.Tests[0]).WebDriver == webTestSuite.WebDriver);
            WebTest driverTest = new WebTest(new ChromeDriver());
            webTestSuite.AddTest(driverTest);
            Assert.AreNotEqual(driverTest.WebDriver, webTestSuite.WebDriver);
            /* Cleanup drivers */
            webTestSuite.WebDriver.Close();
            webTestSuite.WebDriver.Dispose();
            driverTest.WebDriver.Close();
            driverTest.WebDriver.Dispose();
        }
        [TestMethod]
        public void TestSuiteSetUpCleanUpError()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            EpicSuite epicSuite = new EpicSuite();
            ExceptionSuite suite = new ExceptionSuite();
            epicSuite.Suites.Add(suite);
            epicSuite.Execute();
            Assert.IsTrue(sw.ToString().Contains("Exception on TestSuite CleanUp"));
            Assert.IsTrue(sw.ToString().Contains("Exception on TestSuite SetUp"));
            Assert.IsFalse(sw.ToString().Contains("Exception on EpicSuite CleanUp"));
        }
        [TestMethod]
        public void TestEpicSuiteSetUpError()
        {

        }
        [TestMethod]
        public void TestTestSetUpCleanUpError()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            EpicSuite epicSuite = new EpicSuite();
            TestSuite webSuite = new TestSuite();
            webSuite.AddTest(new ExceptionTest());
            epicSuite.Suites.Add(webSuite);
            epicSuite.Execute();
            Assert.IsTrue(sw.ToString().Contains("Exception on Test SetUp"));
            Assert.IsTrue(sw.ToString().Contains("Exception on Test CleanUp"));
            Assert.IsFalse(sw.ToString().Contains("Exception on TestSuite CleanUp"));
            Assert.IsFalse(sw.ToString().Contains("Exception on EpicSuite CleanUp"));
        }

    }
}
