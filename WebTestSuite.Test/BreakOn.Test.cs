using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Exceptions;
using WebTestSuite.Suite;
using WebTestSuite.Test;
using WebTestSuite.Test.SampleTestSuite;

namespace WebSuiteTest.Test
{
    [TestClass]
    public class BreakOn
    {
        [TestMethod]
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

        [TestMethod]
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
        [TestMethod]
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

        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
        public void TestNoBreakOnFailTest()
        {
            SampleEpicSuite epicSuite = new SampleEpicSuite();
            epicSuite.BreakOnFail = false;
            epicSuite.BreakOnEnd = false;
            epicSuite.Suites[0].BreakOnFail = false;
            epicSuite.CleanUp();

        }

        [TestMethod]
        public void EpicSuiteCleanUpException()
        {
            Mock<EpicSuite> epicSuiteMock = new Mock<EpicSuite>();
            epicSuiteMock.Setup(s => s.CleanUp()).Throws(new Exception());
            epicSuiteMock.Object.Execute();            
        }

        [TestMethod]
        public void EpicSuiteSetUpException()
        {
            Mock<EpicSuite> epicSuiteMock = new Mock<EpicSuite>();
            epicSuiteMock.Setup(s => s.SetUp()).Throws(new Exception());
            epicSuiteMock.Object.Execute();
        }
        [TestMethod]
        public void SuiteSetUpException()
        {
            TestSuite suite = new ExceptionSuite();
            suite.Execute();
        }
        [TestMethod]
        public void TestThrowException()
        {
            //Mock<BaseTest> testMock = new Mock<BaseTest>();
            //testMock.Setup(s => s.Execute()).Throws(new FailException());
            ExceptionTest testMock = new ExceptionTest();
            testMock.BreakOnFail = true;
            TestSuite testSuite = new TestSuite();
            testSuite.Tests.Add(testMock);
            testSuite.BreakOnFail = false;
            testSuite.Execute();
            testSuite.Summary.ShowStackTrace = true;
            Assert.IsNotNull(testSuite.Summary.ToString());
            Assert.IsTrue(testSuite.Summary.ToString() is String );
        }
    }
}
