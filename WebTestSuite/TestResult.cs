using System;
using System.Collections.Generic;
using WebTestSuite.Exceptions;

namespace WebTestSuite
{
    public class TestResult : ITestResult
    {
        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; }
        public DateTime ExecutionStart { get; set; }
        public DateTime ExecutionEnd { get; set; }
        public TimeSpan ExecutionTime
        {
            get { return ExecutionEnd - ExecutionStart; }
        }
        public TestFailException Exception { get; set; }
        public TestResult()
        {
            Messages = new List<string>();
        }
    }
}
