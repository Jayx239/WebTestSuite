using System;
using System.Collections.Generic;
using WebTestSuite.Exceptions;

namespace WebTestSuite
{
    /// <summary>
    /// Public test result properties
    /// </summary>
    public interface ITestResult
    {
        /// <summary>
        /// Whether the test was executed
        /// </summary>
        bool Executed { get; set; }
        /// <summary>
        /// Whether the test succeeded
        /// </summary>
        bool Succeeded { get; set; }
        /// <summary>
        /// Test result messages
        /// </summary>
        List<string> Messages { get; set; }
        /// <summary>
        /// Start time of test
        /// </summary>
        DateTime ExecutionStart { get; set; }
        /// <summary>
        /// End time of test
        /// </summary>
        DateTime ExecutionEnd { get; set; }
        /// <summary>
        /// Length of test execution
        /// </summary>
        TimeSpan ExecutionTime { get; }
        /// <summary>
        /// Exception thrown by test if test failed
        /// </summary>
        FailException Exception { get; set; }
    }
}
