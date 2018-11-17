using System;
using System.Collections.Generic;
using WebTestSuite.Exceptions;

namespace WebTestSuite
{
    public interface ITestResult
    {
        bool Succeeded { get; set; }
        List<string> Messages { get; set; }
        DateTime ExecutionStart { get; set; }
        DateTime ExecutionEnd { get; set; }
        TimeSpan ExecutionTime { get; }
        TestFailException Exception { get; set; }
    }
}
