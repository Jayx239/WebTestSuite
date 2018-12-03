using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTestSuite.Exceptions;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
    /// <summary>
    /// Base test suite containing tests
    /// </summary>
    public class TestSuite : ITestSuite, IStateConfiguration
    {
        /// <inheritdoc />
        public bool BreakOnFail { get { return Tests.Exists(r => r.BreakOnFail); } set { foreach (ITest test in Tests) { test.BreakOnFail = value; } } }
        /// <summary>
        /// Description for Suite
        /// </summary>
        public SuiteDescription SuiteDescription { get; set; }
        /// <summary>
        /// Tests to be run in suite
        /// </summary>
        public List<ITest> Tests { get; set; }

        /// <summary>
        /// Test summary for suite
        /// </summary>
        public ITestSummary Summary
        {
            get
            {
                _summary.TestResults.Clear();
                if (Tests != null && Tests.Count > 0)
                    foreach (ITest test in Tests)
                        _summary.TestResults.Add(test.TestResult);

                return _summary;

            }
            set { _summary = value; }
        }
        /// <inheritdoc/>
        private ITestSummary _summary;
        public TestSuite()
        {
            SuiteDescription = new SuiteDescription();
            _summary = new TestSummary();
            Tests = new List<ITest>();
            BreakOnFail = false;
            ShowStackTrace = true;
        }
        public TestSuite(ITestSummary summary) : base()
        {
            _summary = summary;
        }
        public TestSuite(SuiteDescription suiteDescription) : base()
        {
            SuiteDescription = suiteDescription;
        }
        public TestSuite(ITestSummary summary, SuiteDescription suiteDescription) : base()
        {
            SuiteDescription = suiteDescription;
            _summary = summary;
        }

        /// <summary>
        /// Executes all tests in the suite
        /// </summary>
        /// <exception cref="FailException">Thrown if a test fails</exception>
        public void Execute()
        {
            TrySetUp();
            foreach (ITest test in Tests)
            {
                try
                {
                    test.Execute();
                }
                catch (FailException failEx)
                {
                    if (test.BreakOnFail)
                    {
                        TryCleanUp();
                        throw failEx;
                    }
                }
            }
            TryCleanUp();
        }

        /// <summary>
        /// Setup to be run before suite executes
        /// </summary>
        public virtual void SetUp()
        {

        }

        /// <summary>
        /// Safe Set Up that catches exceptions thrown in cleanup method
        /// </summary>
        private void TrySetUp()
        {
            try
            {
                SetUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on TestSuite SetUp");
            }
        }

        /// <summary>
        /// Cleanup to be run after all tests in suite execute
        /// </summary>
        public virtual void CleanUp()
        {
            foreach(ITest test in Tests)
            {
                try
                {
                    test.CleanUp();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception on TestSuite CleanUp");
                }
            }
        }

        /// <summary>
        /// Safe Clean Up that catches exceptions thrown in cleanup method
        /// </summary>
        private void TryCleanUp()
        {
            try
            {
                CleanUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on TestSuite CleanUp");
            }
        }
        /// <summary>
        /// Summaru string detailing results of suite execution
        /// </summary>
        public string SummaryString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(SuiteDescription.ToString()).Append(Summary.ToString());
                return sb.ToString();
            }
        }

        /// <summary>
        /// Pass Fail consolidated string for suite test results
        /// </summary>
        public string PassFailSummaryString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(SuiteDescription.ToString()).Append(Summary.ToPassFailString());
                return sb.ToString();
            }
        }

        /// <inheritdoc />
        public bool ShowStackTrace { get { return _summary.ShowStackTrace; } set { _summary.ShowStackTrace = value; } }

        /// <inheritdoc />
        public bool Sucessful => !Tests.Any(t => !t.TestResult.Succeeded);

        /// <summary>
        /// Prints Summary string
        /// </summary>
        public void PrintSummary()
        {
            Console.WriteLine(SummaryString);
        }

        /// <summary>
        /// Prints pass fail summary
        /// </summary>
        public void PrintPassFailSummary()
        {
            Console.WriteLine(PassFailSummaryString);
        }
    }
}
