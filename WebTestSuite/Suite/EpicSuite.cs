using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestSuite.Suite
{
    public class EpicSuite : ISummaryPrinter
    {

        public EpicSuite()
        {
            Suites = new List<ITestSuite>();
        }

        public List<ITestSuite> Suites { get; set; }
        public bool ShowStackTrace { get { return _showStackTrace;  } set { _showStackTrace = value; foreach (TestSuite suite in Suites) { suite.ShowStackTrace = value; } } }
        
        public void Execute()
        {
            foreach(TestSuite suite in Suites)
            {
                suite.Execute();
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

        public void PrintSummaryString()
        {
            Console.WriteLine(SummaryString);
        }

        public void PrintPassFailSummary()
        {
            Console.WriteLine(PassFailSummaryString);
        }

        private bool _showStackTrace;
    }
}
