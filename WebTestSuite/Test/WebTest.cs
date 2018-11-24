using OpenQA.Selenium;

namespace WebTestSuite.Test
{
    public class WebTest: BaseTest, ITest
    {
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
