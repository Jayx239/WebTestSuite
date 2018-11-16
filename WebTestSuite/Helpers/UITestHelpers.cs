using OpenQA.Selenium;
using WebTestSuite.Exception;

namespace WebTestSuite.Helpers
{
    public static class UITestHelpers
    {
        /// <summary>
        /// Tests if error message is displayed
        /// </summary>
        /// <param name="messageElement">Error message element to be evaluated</param>
        public static void TestErrorMessage(IWebElement messageElement)
        {
            if (!messageElement.Displayed)
                throw new TestFailException("Error message not displayed");
        }
        /// <summary>
        /// Tests if error message is displayed and text matches
        /// </summary>
        /// <param name="messageElement">Error message element to be evaluated</param>
        /// <param name="messageText">Error message text that should be displayed</param>
        public static void TestErrorMessage(IWebElement messageElement, string messageText)
        {
            TestErrorMessage(messageElement);
            if (messageElement.Text != messageText)
                throw new MissMatchException(messageText, messageElement.Text, "Error message miss match");
        }
    }
}
