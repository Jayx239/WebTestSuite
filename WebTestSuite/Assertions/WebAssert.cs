using OpenQA.Selenium;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Assertions
{
    public static class WebAssert
    {
        public static void Matches(object expectedValue, object actualValue)
        {
            if (!expectedValue.Equals(actualValue))
                throw new MissMatchException(expectedValue,actualValue);
        }
        public static void Exists(object value)
        {
            if (value == null)
                throw new ExistsException("Object doe not exist");
        }
        public static void NotExists(object value)
        {
            if (value != null)
                throw new ExistsException("Object doe not exist");
        }
        public static void IsVisible(IWebElement value)
        {
            Exists(value);
            if (!value.Displayed)
                throw new VisibleException("Element is not visible");
        }
        public static void IsHidden(IWebElement value)
        {
            Exists(value);
            if (value.Displayed)
                throw new VisibleException("Element is visible");
        }
        public static void HasAttribute(IWebElement value, string attributeName)
        {
            Exists(value);
            if (value.GetAttribute(attributeName) == null)
                throw new AttributeException("Element does not contain attribute [" + attributeName + "]");
        }
        public static void NotHasAttribute(IWebElement value, string attributeName)
        {
            Exists(value);
            if (value.GetAttribute(attributeName) != null)
                throw new AttributeException("Element contains attribute [" + attributeName + "]");
        }
        public static void TextDisplayed(IWebElement element, string displayText)
        {
            Exists(element);
            IsVisible(element);
            Matches(displayText, element.Text);
        }
    }
}
