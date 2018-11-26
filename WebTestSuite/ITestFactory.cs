namespace WebTestSuite
{
    /// <summary>
    /// Public test factory properties
    /// </summary>
    public interface ITestFactory
    {
        /// <summary>
        /// Gets the test summary
        /// </summary>
        /// <returns>Test Summary</returns>
        ITestSummary GetTestSummary();
    }
}
