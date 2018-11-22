using System.Collections.Generic;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
    public interface ITestSuite : ISummaryPrinter, IBreakable, IStateConfiguration, ISuccessIndicator
    {
        SuiteDescription SuiteDescription { get; set; }
        List<ITest> Tests { get; set; }
        ITestSummary Summary { get; set; }
        void Execute();
    }
}
