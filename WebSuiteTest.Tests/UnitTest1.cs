using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Exceptions;

namespace WebSuiteTest.Test
{
    [TestClass]
    public class UnitTest1
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
            catch(TestFailException failEx)
            {
                
            }
        }
    }
}
