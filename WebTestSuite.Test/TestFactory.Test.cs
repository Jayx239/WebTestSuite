using System;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebTestSuite.Test
{
    [TestFixture]
    public class TestFactory
    {
        [Test]
        public void TestGetTestSummary()
        {
            WebTestSuite.TestFactory testFactory = new WebTestSuite.TestFactory();
            Assert.IsInstanceOfType(testFactory.GetTestSummary(), typeof(WebTestSuite.TestSummary));
        }
    }
}
