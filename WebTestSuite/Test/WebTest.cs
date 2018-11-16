using OpenQA.Selenium;

namespace WebTestSuite.Test
{
    public class WebTest: BaseTest, ITest
    {
        protected IWebDriver _webDriver;

        public WebTest(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
