namespace WebTestSuite.Test
{
    /// <summary>
    /// Public test attributes
    /// </summary>
    public interface ITest : IBreakable, IStateConfiguration, ISuccessIndicator
    {
        /// <summary>
        /// Test result for test
        /// </summary>
        ITestResult TestResult { get; set; }
        /// <summary>
        /// Execute test
        /// </summary>
        void Execute();
    }
}
