using System;
using System.Collections.Generic;
using WebTestSuite.Exceptions;

namespace WebTestSuite
{
    public class TestResult : ITestResult
    {
        public bool Executed { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; }
        public DateTime ExecutionStart { get; set; }
        public DateTime ExecutionEnd { get; set; }
        public TimeSpan ExecutionTime
        {
            get { return ExecutionEnd - ExecutionStart; }
        }
        public FailException Exception { get; set; }

        public TestResult()
        {
            Executed = false;
            Messages = new List<string>();
        }
    }
}
