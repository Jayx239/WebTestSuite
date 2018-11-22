using System;

namespace WebTestSuite.Test.SampleTestSuite
{
    class ExceptionTest : BaseTest
    {
        protected override bool TryTest()
        {
            throw new Exception();
        }

        public override void SetUp()
        {
            throw new Exception();
        }

        public override void CleanUp()
        {
            throw new Exception();
            base.CleanUp();
        }
    }
}
