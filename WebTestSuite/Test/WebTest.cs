using OpenQA.Selenium;

namespace WebTestSuite.Test
{
    /// <summary>
    /// Web test base class
    /// </summary>
    public class WebTest: BaseTest, ITest
    {
        /// <summary>
        /// Web Driver to be shared between tests
        /// </summary>
        public IWebDriver WebDriver { get; set; }
        
        public WebTest(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public WebTest()
        {

        }
    }
}
