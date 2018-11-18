namespace WebTestSuite.Test
{
    public interface ITest : IBreakable, IStateConfiguration
    {
        ITestResult TestResult { get; set; }
        void Execute();
    }
}
