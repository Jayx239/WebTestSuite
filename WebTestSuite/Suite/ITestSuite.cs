using System.Collections.Generic;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
    public interface ITestSuite : ISummaryPrinter
    {
        SuiteDescription SuiteDescription { get; set; }
        List<ITest> Tests { get; set; }
        ITestSummary Summary { get; set; }
        void Execute();
    }
}
