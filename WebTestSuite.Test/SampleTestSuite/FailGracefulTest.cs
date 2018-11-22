using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestSuite.Test.SampleTestSuite
{
    class FailGracefulTest : BaseTest
    {
        protected override bool TryTest()
        {
            return false;
        }
    }
}
