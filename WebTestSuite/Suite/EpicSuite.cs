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
    public class EpicSuite : ISummaryPrinter, IBreakable, IStateConfiguration, ISuccessIndicator
    {

        public EpicSuite()
        {
            Suites = new List<ITestSuite>();
            PrintSummaryOnComplete = true;
            BreakOnFail = false;
        }

        public bool BreakOnFail { get; set; }
        /// <summary>
        /// Determines whether an exception should be thrown after all tests are ran if one or more suites failed
        /// </summary>
        public bool BreakOnEnd { get; set; }
        public List<ITestSuite> Suites { get; set; }
        public bool ShowStackTrace { get { return Suites.Any(s=> s.ShowStackTrace); } set { foreach (TestSuite suite in Suites) { suite.ShowStackTrace = value; } } }
        public bool PrintSummaryOnComplete { get; set; }
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

        public bool Sucessful => !Suites.Exists(s=>!s.Sucessful);

        public void PrintSummary()
        {
            Console.WriteLine(SummaryString);
        }

        public void PrintPassFailSummary()
        {
            Console.WriteLine(PassFailSummaryString);
        }

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
                Console.WriteLine("Exception on EpicSuite SetUp");
            }
        }
        public virtual void CleanUp()
        {
            foreach (var suite in Suites)
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
        private void TryCleanUp()
        {
            try
            {
                CleanUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception on EpicSuite CleanUp");
            }
        }
    }
}
