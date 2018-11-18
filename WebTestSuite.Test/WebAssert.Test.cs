using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WebTestSuite.Exceptions;

namespace WebTestSuite.Test
{
    [TestClass]
    public class WebAssert
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        #region Failed methods
        [TestMethod]
        public void MatchesFail()
        {
            try
            {
                WebTestSuite.Assertions.WebAssert.Matches("true", "false");
            }
            catch (MissMatchException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void ExistsFail()
        {
            try
            {
                WebTestSuite.Assertions.WebAssert.Exists(null);
            }
            catch (ExistsException ex)
            {
                return;
            }
            Assert.IsFalse(true);

        }
        [TestMethod]
        public void NotExistsFail()
        {
            try
            {
                WebTestSuite.Assertions.WebAssert.NotExists("exists");
            }
            catch (ExistsException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void IsVisibleFail()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.Displayed).Returns(false);
            try
            {
                WebTestSuite.Assertions.WebAssert.IsVisible(webElement.Object);
            }
            catch (VisibleException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void IsHiddenFail()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.Displayed).Returns(true);
            try
            {
                WebTestSuite.Assertions.WebAssert.IsHidden(webElement.Object);
            }
            catch (VisibleException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void HasAttributeFail()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            //webElement.Setup(elem => elem.GetAttribute("placeholder")).Returns(false);
            try
            {
                WebTestSuite.Assertions.WebAssert.HasAttribute(webElement.Object, "placeholder");
            }
            catch (AttributeException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void NotHasAttributeFail()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.GetAttribute("placeholder")).Returns("one");
            try
            {
                WebTestSuite.Assertions.WebAssert.NotHasAttribute(webElement.Object, "placeholder");
            }
            catch (AttributeException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void TextDisplayedHiddenFail()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.Displayed).Returns(false);
            try
            {
                WebTestSuite.Assertions.WebAssert.TextDisplayed(webElement.Object, "Correct Text");
            }
            catch (VisibleException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        [TestMethod]
        public void TextDisplayedTextMissMatchFail()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.Displayed).Returns(true);
            webElement.Setup(elem => elem.Text).Returns("Incorrect Text");
            try
            {
                WebTestSuite.Assertions.WebAssert.TextDisplayed(webElement.Object, "Correct Text");
            }
            catch (MissMatchException ex)
            {
                return;
            }
            Assert.IsFalse(true);
        }
        #endregion

        #region Passed tests
        [TestMethod]
        public void MatchesPass()
        {
            WebTestSuite.Assertions.WebAssert.Matches("true", "true");
        }
        [TestMethod]
        public void ExistsPass()
        {
            WebTestSuite.Assertions.WebAssert.Exists("Asd");
        }
        [TestMethod]
        public void NotExistsPass()
        {
            WebTestSuite.Assertions.WebAssert.NotExists(null);
        }
        [TestMethod]
        public void IsVisiblePass()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.Displayed).Returns(true);

            WebTestSuite.Assertions.WebAssert.IsVisible(webElement.Object);

        }
        [TestMethod]
        public void IsHiddenPass()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.Displayed).Returns(false);
            WebTestSuite.Assertions.WebAssert.IsHidden(webElement.Object);
        }
        [TestMethod]
        public void HasAttributePass()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.GetAttribute("placeholder")).Returns("placeholder");
            WebTestSuite.Assertions.WebAssert.HasAttribute(webElement.Object, "placeholder");

        }
        [TestMethod]
        public void NotHasAttributePass()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            WebTestSuite.Assertions.WebAssert.NotHasAttribute(webElement.Object, "placeholder");
        }
        [TestMethod]
        public void TextDisplayedPass()
        {
            Mock<IWebElement> webElement = new Mock<IWebElement>();
            webElement.Setup(elem => elem.Displayed).Returns(true);
            webElement.Setup(elem => elem.Text).Returns("Correct Text");
            WebTestSuite.Assertions.WebAssert.TextDisplayed(webElement.Object, "Correct Text");
        }
        #endregion
    }
}