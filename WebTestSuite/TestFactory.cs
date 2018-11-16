namespace WebTestSuite
{
    public class TestFactory : ITestFactory
    {
        public ITestSummary GetTestSummary()
        {
            return new TestSummary();
        }
    }
}
