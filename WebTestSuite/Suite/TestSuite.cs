using System;
using System.Collections.Generic;
using System.Text;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
    public class TestSuite : ITestSuite
    {
        public SuiteDescription SuiteDescription { get; set; }
        public List<ITest> Tests { get; set; }

        public ITestSummary Summary
        {
            get
            {
                _summary.TestResults.Clear();
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

        public virtual void Execute()
        {
            foreach (ITest test in Tests)
            {
                test.Execute();
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
