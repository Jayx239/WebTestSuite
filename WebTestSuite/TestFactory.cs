namespace WebTestSuite
{
    /// <summary>
    /// Factory for getting test configurations
    /// </summary>
    public class TestFactory : ITestFactory
    {
        /// <inheritdoc />
        public ITestSummary GetTestSummary()
        {
            return new TestSummary();
        }
    }
}
