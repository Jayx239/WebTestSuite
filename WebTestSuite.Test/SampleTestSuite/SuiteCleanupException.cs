using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestSuite.Suite;

namespace WebTestSuite.Test.SampleTestSuite
{
    class SuiteCleanupException : TestSuite
    {
        public override void CleanUp()
        {
            throw new Exception();
        }
    }
}
