using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebTestSuite.Test
{
    [TestFixture]
    public class SuiteDescription
    {
        [Test]
        public void TestMethod1()
        {
            WebTestSuite.Suite.SuiteDescription suiteDescription = new WebTestSuite.Suite.SuiteDescription("Suite name", "Client");
            Assert.AreEqual(suiteDescription.SuiteName, "Suite name");
            Assert.AreEqual(suiteDescription.Client, "Client");
        }
    }
}
