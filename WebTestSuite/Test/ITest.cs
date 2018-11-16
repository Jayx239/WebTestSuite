namespace WebTestSuite.Test
{
    public interface ITest
    {
        ITestResult TestResult { get; set; }
        void Execute();
    }
}
