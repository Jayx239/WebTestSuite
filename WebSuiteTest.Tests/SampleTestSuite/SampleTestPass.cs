using OpenQA.Selenium;
using WebTestSuite.Test;

namespace WebSuiteTest.Test.SampleTestSuite
{
    public class SampleTestPass : WebTest
    {
        public SampleTestPass(IWebDriver webDriver) : base(webDriver)
        {
        }

        protected override bool TryTest()
        {
            return base.TryTest();
        }
    }
}
