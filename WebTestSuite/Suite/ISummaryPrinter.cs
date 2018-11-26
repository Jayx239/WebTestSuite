namespace WebTestSuite.Suite
{
    /// <summary>
    /// Print functionality
    /// </summary>
    public interface ISummaryPrinter
    {
        /// <summary>
        /// Show stack trace when printing
        /// </summary>
        bool ShowStackTrace { get; set; }
        /// <summary>
        /// Gets a summary string
        /// </summary>
        string SummaryString { get; }
        /// <summary>
        /// Gets a consolidated pass fail summary string
        /// </summary>
        string PassFailSummaryString { get; }
        /// <summary>
        /// Prints the summary string to the console
        /// </summary>
        void PrintSummary();
        /// <summary>
        /// Prints the pass fail summary to the console
        /// </summary>
        void PrintPassFailSummary();
    }
}
