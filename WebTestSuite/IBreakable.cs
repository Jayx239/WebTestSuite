namespace WebTestSuite
{
    /// <summary>
    /// Breakable public attributes
    /// </summary>
    public interface IBreakable
    {
        /// <summary>
        /// Determines whether to handle or throw an exception when execution fails
        /// </summary>
        bool BreakOnFail { get; set; }
    }
}
