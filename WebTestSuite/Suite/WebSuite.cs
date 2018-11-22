using OpenQA.Selenium;
using WebTestSuite.Test;

namespace WebTestSuite.Suite
{
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
