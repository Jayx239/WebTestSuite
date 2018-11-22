using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.IsFalse(base.TryTest());
            return true;
        }
        public override void CleanUp()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }
    }
}
