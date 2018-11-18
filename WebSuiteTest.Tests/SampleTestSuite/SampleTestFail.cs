using OpenQA.Selenium;
using WebTestSuite.Exceptions;
using WebTestSuite.Test;

namespace WebSuiteTest.Test.SampleTestSuite
{
    public class SampleTestFail : WebTest
    {
        public SampleTestFail(IWebDriver webDriver) : base(webDriver)
        {
        }
        protected override bool TryTest()
        {
            throw new AttributeException();
        }
    }
}
