using System.Collections.Generic;

namespace WebTestSuite
{
    /// <summary>
    /// Public test summary properties
    /// </summary>
    public interface ITestSummary
    {
        /// <summary>
        /// Test results
        /// </summary>
        List<ITestResult> TestResults { get; set; }
        /// <summary>
        /// Show stack trace for failed tests in test result string
        /// </summary>
        bool ShowStackTrace { get; set; }
        /// <summary>
        /// Test results summary string
        /// </summary>
        /// <returns>Test results summary</returns>
        string ToString();
        /// <summary>
        /// Condensed test result summary string, shows which tests passed and failed
        /// </summary>
        /// <returns>Pass/Fail test summary</returns>
        string ToPassFailString();
    }
}
