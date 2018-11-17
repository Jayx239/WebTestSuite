using System;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Test
{
    public class BaseTest : ITest
    {
        public ITestResult TestResult { get; set; }

        public void Execute()
        {
            try
            {
                TestResult.Succeeded = false;
                TestResult.ExecutionStart = DateTime.Now;
                if (TryTest()) {
                    TestResult.ExecutionEnd = DateTime.Now;
                    TestResult.Succeeded = true;
                    TestResult.Messages.Add("Test passed");
                }
                else
                {
                    TestResult.ExecutionEnd = DateTime.Now;
                    TestResult.Messages.Add("Test failed gracefully");
                }
            }
            catch (TestFailException failEx)
            {
                TestResult.ExecutionEnd = DateTime.Now;
                TestResult.Succeeded = false;
                TestResult.Messages.Add(failEx.Message);
                TestResult.Exception = failEx;
            }
            catch (Exception ex)
            {
                TestResult.ExecutionEnd = DateTime.Now;
                TestResult.Succeeded = false;
                TestResult.Messages.Add(ex.Message);
                TestResult.Exception = new UnexpectedErrorException(ex.Message, ex);
            }
        }
        protected virtual bool TryTest()
        {
            return false;
        }

        public BaseTest()
        {
            TestResult = new TestResult();
        }

        public BaseTest(ITestResult testResult)
        {
            TestResult = testResult;
        }

    }
}
