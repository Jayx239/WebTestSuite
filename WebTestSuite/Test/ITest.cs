namespace WebTestSuite.Test
{
    public interface ITest : IBreakable, IStateConfiguration, ISuccessIndicator
    {
        ITestResult TestResult { get; set; }
        void Execute();
    }
}
