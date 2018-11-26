using System;
using System.Collections.Generic;
using WebTestSuite.Exceptions;

namespace WebTestSuite
{
    /// <summary>
    /// Test result details
    /// </summary>
    public class TestResult : ITestResult
    {
        /// <inheritdoc />
        public bool Executed { get; set; }
        /// <inheritdoc />
        public bool Succeeded { get; set; }
        /// <inheritdoc />
        public List<string> Messages { get; set; }
        /// <inheritdoc />
        public DateTime ExecutionStart { get; set; }
        /// <inheritdoc />
        public DateTime ExecutionEnd { get; set; }
        /// <inheritdoc />
        public TimeSpan ExecutionTime
        {
            get { return ExecutionEnd - ExecutionStart; }
        }
        /// <inheritdoc />
        public FailException Exception { get; set; }
        /// <inheritdoc />
        public TestResult()
        {
            Executed = false;
            Messages = new List<string>();
        }
    }
}
