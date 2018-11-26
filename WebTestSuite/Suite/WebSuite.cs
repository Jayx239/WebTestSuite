using OpenQA.Selenium;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
    /// <summary>
    /// Suite containing web tests
    /// </summary>
    public class WebSuite : TestSuite
    {
        public IWebDriver WebDriver { get; set; }
        
        public WebSuite()
        {
            WebDriver = null;
        }
        public WebSuite(IWebDriver driver)
        {
            WebDriver = driver;
        }

        /// <summary>
        /// Adds test, setting the test WebDriver to this WebDriver if the tests is null
        /// </summary>
        /// <param name="test">Test to be added</param>
        public void AddTest(WebTest test)
        {
            if(test.WebDriver == null)
            {
                test.WebDriver = WebDriver;
            }
            this.Tests.Add(test);
        }
    }
}
