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
            return true;
        }
        public override void CleanUp()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}
