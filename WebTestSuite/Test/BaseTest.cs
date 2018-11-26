using System;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Test
{
    /// <summary>
    /// Base test class
    /// </summary>
    public class BaseTest : ITest
    {
        /// <inheritdoc />
        public bool BreakOnFail { get; set; }

        /// <inheritdoc />
        public ITestResult TestResult { get; set; }

        /// <summary>
        /// Indicates whether the test succeeded
        /// </summary>
        public bool Sucessful => TestResult.Succeeded;

        /// <summary>
        /// Setup tasks to be run before test is run
        /// </summary>
        public virtual void SetUp()
        {
            
        }

        /// <summary>
        /// Safe setup, catches exceptions thrown by setup
        /// </summary>
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

        /// <summary>
        /// Clean up tasks to be run after each test
        /// </summary>
        public virtual void CleanUp()
        {
            
        }

        /// <summary>
        /// Safe cleanup, catches exceptions thrown by cleanup
        /// </summary>
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

        /// <summary>
        /// Executes tests
        /// </summary>
        /// <exception cref="FailException"></exception>
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

        /// <summary>
        /// Test logic, this should be overriden with test logic
        /// </summary>
        /// <returns></returns>
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
