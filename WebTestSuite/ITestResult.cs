using System;
using System.Collections.Generic;
using WebTestSuite.Exceptions;

namespace WebTestSuite
{
    public interface ITestResult
    {
        bool Executed { get; set; }
        bool Succeeded { get; set; }
        List<string> Messages { get; set; }
        DateTime ExecutionStart { get; set; }
        DateTime ExecutionEnd { get; set; }
        TimeSpan ExecutionTime { get; }
        FailException Exception { get; set; }
    }
}
