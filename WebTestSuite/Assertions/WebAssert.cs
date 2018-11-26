using OpenQA.Selenium;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Assertions
{
    /// <summary>
    /// Contains helpful assertions for web tests
    /// </summary>
    public static class WebAssert
    {
        /// <summary>
        /// Asserts two objects match
        /// </summary>
        /// <param name="expectedValue">Expected value</param>
        /// <param name="actualValue">Actual value</param>
        /// <exception cref="MissMatchException">Thrown if the actual value does not equal the expected value</exception>
        public static void Matches(object expectedValue, object actualValue)
        {
            if (!expectedValue.Equals(actualValue))
                throw new MissMatchException(expectedValue,actualValue);
        }
        /// <summary>
        /// Asserts an object exists
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <exception cref="ExistsException">Thrown if the input object is null</exception>
        public static void Exists(object value)
        {
            if (value == null)
                throw new ExistsException("Object doe not exist");
        }
        /// <summary>
        /// Asserts an object does not exist
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <exception cref="ExistsException">Thrown if the input object is not null</exception>
        public static void NotExists(object value)
        {
            if (value != null)
                throw new ExistsException("Object doe not exist");
        }
        /// <summary>
        /// Asserts an element is visible
        /// </summary>
        /// <param name="value">Web Element to be checked</param>
        /// <exception cref="VisibleException">Thrown if the element is not visible</exception>
        public static void IsVisible(IWebElement value)
        {
            Exists(value);
            if (!value.Displayed)
                throw new VisibleException("Element is not visible");
        }
        /// <summary>
        /// Asserts an element is hidden
        /// </summary>
        /// <param name="value">Web Element to be checked</param>
        /// <exception cref="VisibleException">Thrown if the element is visible</exception>
        public static void IsHidden(IWebElement value)
        {
            Exists(value);
            if (value.Displayed)
                throw new VisibleException("Element is visible");
        }
        /// <summary>
        /// Asserts a Web Element contains an attribute
        /// </summary>
        /// <param name="value">Web Element to be checked</param>
        /// <param name="attributeName">Attribute that the Web Element is expected to contain</param>
        /// <exception cref="AttributeException">Thrown if the Web Element does not contain the expected attribute</exception>
        public static void HasAttribute(IWebElement value, string attributeName)
        {
            Exists(value);
            if (value.GetAttribute(attributeName) == null)
                throw new AttributeException("Element does not contain attribute [" + attributeName + "]");
        }
        /// <summary>
        /// Asserts a Web Element does not contain an attribute
        /// </summary>
        /// <param name="value">Web Element to be checked</param>
        /// <param name="attributeName">Attribute the Web Element should not contain</param>
        /// <exception cref="AttributeException">Thrown if the Web Element contains the attribute</exception>
        public static void NotHasAttribute(IWebElement value, string attributeName)
        {
            Exists(value);
            if (value.GetAttribute(attributeName) != null)
                throw new AttributeException("Element contains attribute [" + attributeName + "]");
        }
        /// <summary>
        /// Asserts that the Web Element is displayed with the expected text
        /// </summary>
        /// <param name="element">Web Element to be checked</param>
        /// <param name="displayText">The text that the Web Element is expected to display</param>
        public static void TextDisplayed(IWebElement element, string displayText)
        {
            Exists(element);
            IsVisible(element);
            Matches(displayText, element.Text);
        }
    }
}
