using OpenQA.Selenium;
using WebTestSuite.Exceptions;
using WebTestSuite.Test;

namespace WebSuiteTest.Test.SampleTestSuite
{
    public class SampleTest2 : WebTest
    {
        public SampleTest2(IWebDriver webDriver) : base(webDriver)
        {
        }

        protected override bool TryTest()
        {
            throw new AttributeException();
        }
    }
}
