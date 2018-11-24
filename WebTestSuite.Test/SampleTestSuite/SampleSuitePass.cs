using OpenQA.Selenium.Chrome;
using WebSuiteTest.Test.SampleTestSuite;
using WebTestSuite.Suite;

namespace WebTestSuite.Test.SampleTestSuite
{
    class SampleSuitePass : TestSuite
    {
        public SampleSuitePass() : base()
        {
            this.SuiteDescription.Client = "Sample";
            this.SuiteDescription.SuiteName = "Sample tests";
            this.Tests.Add(new SampleTestPass(new ChromeDriver()));
            this.Tests.Add(new SampleTestPass(new ChromeDriver()));
        }
    }
}
