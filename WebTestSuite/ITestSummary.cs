using System.Collections.Generic;

namespace WebTestSuite
{
    public interface ITestSummary
    {
        List<ITestResult> TestResults { get; set; }
        bool ShowStackTrace { get; set; }
        string ToString();
        string ToPassFailString();
    }
}
