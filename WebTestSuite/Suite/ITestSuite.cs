using System.Collections.Generic;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
    /// <summary>
    /// Public attributes of test suite
    /// </summary>
    public interface ITestSuite : ISummaryPrinter, IBreakable, IStateConfiguration, ISuccessIndicator, IStateConfigurationStatus
    {
        /// <summary>
        /// Description of suite
        /// </summary>
        SuiteDescription SuiteDescription { get; set; }
        /// <summary>
        /// List of tests to be run when suite is executed
        /// </summary>
        List<ITest> Tests { get; set; }
        /// <summary>
        /// Summary of test suite
        /// </summary>
        ITestSummary Summary { get; set; }
        /// <summary>
        /// Execute tests in Tests list
        /// </summary>
        void Execute();

        /// <summary>
        /// Adds test to suite
        /// </summary>
        /// <param name="test">Test to be added</param>
        void AddTest(ITest test);
    }
}
