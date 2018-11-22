using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTestSuite.Exceptions;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
    public class TestSuite : ITestSuite, IStateConfiguration
    {
        public bool BreakOnFail { get { return Tests.Exists(r => r.BreakOnFail); } set { foreach (ITest test in Tests) { test.BreakOnFail = value; } } }
        public SuiteDescription SuiteDescription { get; set; }
        public List<ITest> Tests { get; set; }

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
                Console.WriteLine("Exception on TestSuite SetUp");
            }
        }

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
        public string SummaryString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(SuiteDescription.ToString()).Append(Summary.ToString());
                return sb.ToString();
            }
        }

        public string PassFailSummaryString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(SuiteDescription.ToString()).Append(Summary.ToPassFailString());
                return sb.ToString();
            }
        }

        public bool ShowStackTrace { get { return _summary.ShowStackTrace; } set { _summary.ShowStackTrace = value; } }

        public bool Sucessful => !Tests.Any(t => !t.TestResult.Succeeded);

        public void PrintSummaryString()
        {
            Console.WriteLine(SummaryString);
        }

        public void PrintPassFailSummary()
        {
            Console.WriteLine(PassFailSummaryString);
        }
    }
}
