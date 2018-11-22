using System;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Test
{
    public class BaseTest : ITest
    {
        public bool BreakOnFail { get; set; }

        public ITestResult TestResult { get; set; }

        public bool Sucessful => TestResult.Succeeded;

        public virtual void SetUp()
        {
            
        }

        private void TrySetUp()
        {
            try
            {
                SetUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on Test SetUp");
            }
        }

        public virtual void CleanUp()
        {
            
        }

        private void TryCleanUp()
        {
            try
            {
                CleanUp();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception on Test CleanUp");
            }
        }

        public void Execute()
        {
            TrySetUp();
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
                    TryCleanUp();
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
                    TryCleanUp();
                    throw TestResult.Exception;
                }
            }
            TestResult.Executed = true;
            TryCleanUp();
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
