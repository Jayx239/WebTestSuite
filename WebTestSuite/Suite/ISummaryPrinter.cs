namespace WebTestSuite.Suite
{
    public interface ISummaryPrinter
    {
        bool ShowStackTrace { get; set; }
        string SummaryString { get; }
        string PassFailSummaryString { get; }
        void PrintSummaryString();
        void PrintPassFailSummary();
    }
}
