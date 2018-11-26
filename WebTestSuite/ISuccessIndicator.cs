namespace WebTestSuite
{
    /// <summary>
    /// Success properties
    /// </summary>
    public interface ISuccessIndicator
    {
        /// <summary>
        /// Indicates whether an operation was successful
        /// </summary>
        bool Sucessful { get; }
    }
}
