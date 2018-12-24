using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Suite
{
    /// <summary>
    /// Contains test suites to be executed
    /// </summary>
    public class EpicSuite : ISummaryPrinter, IBreakable, IStateConfiguration, ISuccessIndicator, IStateConfigurationStatus
    {

        public EpicSuite()
        {
            Suites = new List<ITestSuite>();
            PrintSummaryOnComplete = true;
            BreakOnFail = false;
            IsSetUp = false;
            IsCleanedUp = false;
            SetUpFailed = false;
            CleanUpFailed = false;
        }
        /// <inheritdoc/>
        public bool BreakOnFail { get; set; }
        /// <summary>
        /// Determines whether an exception should be thrown after all tests are ran if one or more suites failed
        /// </summary>
        public bool BreakOnEnd { get; set; }
        /// <summary>
        /// Suites to be run on Execute
        /// </summary>
        public List<ITestSuite> Suites { get; set; }
        /// <inheritdoc/>
        public bool ShowStackTrace { get { return Suites.Any(s=> s.ShowStackTrace); } set { foreach (TestSuite suite in Suites) { suite.ShowStackTrace = value; } } }
        /// <summary>
        /// Indicates whether to print test summary when EpicSuite finishes execution
        /// </summary>
        public bool PrintSummaryOnComplete { get; set; }
        /// <summary>
        /// Executes all suites in the epic
        /// </summary>
        public void Execute()
        {
            TrySetUp();
            foreach (TestSuite suite in Suites)
            {
                try
                {
                    suite.Execute();
                }
                catch (FailException failEx)
                {
                    if (BreakOnFail)
                    {
                        TryCleanUp();
                        if (PrintSummaryOnComplete)
                        {
                            PrintPassFailSummary();
                            PrintSummary();
                        }
                        
                        throw failEx;
                    }
                }
            }

            TryCleanUp();
            if (PrintSummaryOnComplete)
            {
                PrintPassFailSummary();
                PrintSummary();
            }
            
            if(BreakOnEnd)
            {
                if (!Sucessful)
                    throw new SuiteFailException();
            }
        }

        /// <summary>
        /// Gets a summary string of the Epic Suite execution result
        /// </summary>
        public string SummaryString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (ITestSuite testSuite in Suites)
                {
                    sb.Append(testSuite.SummaryString).Append("\n");
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets a consolidated summary of the Epic Suite execution result
        /// </summary>
        public string PassFailSummaryString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (ITestSuite testSuite in Suites)
                {
                    sb.Append(testSuite.PassFailSummaryString).Append("\n");
                }
                return sb.ToString();
            }
        }

        /// <inheritdoc/>
        public bool Sucessful => !Suites.Exists(s=>!s.Sucessful);
        /// <summary>
        /// Prints a summary string of the Epic Suite execution result
        /// </summary>
        public void PrintSummary()
        {
            Console.WriteLine(SummaryString);
        }
        /// <summary>
        /// Prints a consolidated summary of the Epic Suite execution result
        /// </summary>
        public void PrintPassFailSummary()
        {
            Console.WriteLine(PassFailSummaryString);
        }
        /// <summary>
        /// Performs Set Up operations for the Epic Suite
        /// </summary>
        public virtual void SetUp()
        {
            
        }
        /// <summary>
        /// Safely runs the Set Up operations for the Epic Suite before execution starts
        /// </summary>
        private void TrySetUp()
        {
            IsSetUp = false;
            SetUpFailed = false;
            try
            {
                SetUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on EpicSuite SetUp");
                IsSetUp = false;
                SetUpFailed = true;
                return;
            }
            IsSetUp = true;
            SetUpFailed = false;
        }
        /// <summary>
        /// Performs the Clean Up operations for the Epic Suite when execution is finished
        /// </summary>
        public virtual void CleanUp()
        {
            foreach (var suite in Suites.Where(s=>s.ShouldCleanUp))
            {
                try
                {
                    suite.CleanUp();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception on EpicSuite CleanUp");
                }
            }
        }
        /// <summary>
        /// Safely runs the Clean Up operations for Epic Suite when execution is finished
        /// </summary>
        private void TryCleanUp()
        {
            IsCleanedUp = false;
            CleanUpFailed = true;
            try
            {
                CleanUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on EpicSuite CleanUp");
                IsCleanedUp = false;
                CleanUpFailed = true;
                return;
            }

            IsCleanedUp = true;
            CleanUpFailed = false;
        }

        /// <inheritdoc />
        public bool IsSetUp { get; set; }

        /// <inheritdoc />
        public bool IsCleanedUp { get; set; }

        /// <inheritdoc />
        public bool SetUpFailed { get; set; }

        /// <inheritdoc />
        public bool CleanUpFailed { get; set; }
        
        /// <inheritdoc />
        public bool ShouldCleanUp { get { return !IsCleanedUp && !CleanUpFailed; } }
    }
}
