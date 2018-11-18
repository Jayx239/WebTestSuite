using System;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Test
{
    public class BaseTest : ITest, ISuccessIndicator
    {
        public bool BreakOnFail { get; set; }

        public ITestResult TestResult { get; set; }

        public bool Sucessful => TestResult.Succeeded;

        public virtual void SetUp()
        {
            
        }

        public virtual void CleanUp()
        {
            
        }

        public void Execute()
        {
            SetUp();
            try
            {
                TestResult.Succeeded = false;
                TestResult.ExecutionStart = DateTime.Now;
                if (TryTest())
                {
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
            catch (FailException failEx)
            {
                TestResult.ExecutionEnd = DateTime.Now;
                TestResult.Succeeded = false;
                TestResult.Messages.Add(failEx.Message);
                TestResult.Exception = failEx;
                TestResult.Executed = true;
                if (BreakOnFail)
                {
                    CleanUp();
                    throw failEx;
                }
                    
            }
            catch (Exception ex)
            {
                TestResult.ExecutionEnd = DateTime.Now;
                TestResult.Succeeded = false;
                TestResult.Messages.Add(ex.Message);
                TestResult.Exception = new UnexpectedErrorException(ex.Message, ex);
                TestResult.Executed = true;
                if (BreakOnFail)
                {
                    CleanUp();
                    throw TestResult.Exception;
                }
            }
            TestResult.Executed = true;
            CleanUp();
        }

        protected virtual bool TryTest()
        {
            return false;
        }

        public BaseTest()
        {
            BreakOnFail = false;
            TestResult = new TestResult();
        }

        public BaseTest(ITestResult testResult)
        {
            BreakOnFail = false;
            TestResult = testResult;
        }

    }
}
