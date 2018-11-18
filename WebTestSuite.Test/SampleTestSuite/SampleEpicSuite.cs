using WebTestSuite.Suite;

namespace WebSuiteTest.Test.SampleTestSuite
{
    public class SampleEpicSuite : EpicSuite
    {
        public SampleEpicSuite() : base()
        {
            this.Suites.Add(new SampleSuite());
        }
    }
}
