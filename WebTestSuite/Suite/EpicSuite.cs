using System;
using System.Collections.Generic;
using System.Text;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Suite
{
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
        public bool ShowStackTrace { get { return _showStackTrace; } set { _showStackTrace = value; foreach (TestSuite suite in Suites) { suite.ShowStackTrace = value; } } }
        public bool PrintSummaryOnComplete { get; set; }
        public void Execute()
        {
            SetUp();
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
                        if (PrintSummaryOnComplete)
                        {
                            PrintPassFailSummary();
                            PrintSummaryString();
                        }
                        CleanUp();
                        throw failEx;
                    }
                }
            }

            if (PrintSummaryOnComplete)
            {
                PrintPassFailSummary();
                PrintSummaryString();
            }
            CleanUp();
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

        public void PrintSummaryString()
        {
            Console.WriteLine(SummaryString);
        }

        public void PrintPassFailSummary()
        {
            Console.WriteLine(PassFailSummaryString);
        }

        public void SetUp()
        {
            
        }

        public void CleanUp()
        {
            foreach (var suite in Suites)
            {
                try
                {
                    suite.CleanUp();
                }
                catch (Exception e)
                {
                    // Do nothing right now
                }
            }
        }

        private bool _showStackTrace;
    }
}
