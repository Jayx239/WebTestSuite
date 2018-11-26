using System.Collections.Generic;
using System.Text;

namespace WebTestSuite
{
    /// <summary>
    /// Test results summary
    /// </summary>
    public class TestSummary : ITestSummary
    {
        /// <inheritdoc />
        public List<ITestResult> TestResults { get; set; }
        /// <inheritdoc />
        public bool ShowStackTrace { get; set; }
        /// <inheritdoc cref="ITestSummary"/>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach(ITestResult testResult in TestResults)
            {
                sb.Append(string.Format("Test {0}:\n\tExecuted: {1}\n\tSucceeded: {2}\n\tMessage: ", index++, testResult.Executed, testResult.Succeeded));
                foreach (string message in testResult.Messages)
                    sb.Append("\n\t\t").Append(message);
                sb.Append(string.Format("\n\tStart: {0}\n\tStop: {1}\n\tExecution Time: {2}\n", testResult.ExecutionStart, testResult.ExecutionEnd, testResult.ExecutionTime));
                if(ShowStackTrace && testResult.Exception != null)
                {
                    sb.Append("Stack Trace:\n").Append(testResult.Exception.StackTrace);
                }
                sb.Append("\n\n");
            }
            return sb.ToString();
        }

        /// <inheritdoc />
        public string ToPassFailString()
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (ITestResult testResult in TestResults)
            {
                sb.Append(string.Format("Test {0}: {1}\n", index++, testResult.Succeeded ? "Passed" : "Failed" ));
            }
            return sb.ToString();
        }

        /// <inheritdoc />
        public TestSummary()
        {
            TestResults = new List<ITestResult>();
        }
    }
}
