namespace WebTestSuite
{
    /// <summary>
    /// Configuration for execution
    /// </summary>
    public interface IStateConfiguration
    {
        /// <summary>
        /// Setup tasks ran before execution
        /// </summary>
        void SetUp();
        /// <summary>
        /// Cleanup tasks run after execution
        /// </summary>
        void CleanUp();
    }
}
