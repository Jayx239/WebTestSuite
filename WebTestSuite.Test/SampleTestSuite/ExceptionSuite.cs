using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestSuite.Suite;

namespace WebTestSuite.Test.SampleTestSuite
{
    class ExceptionSuite : TestSuite
    {
        public override void SetUp()
        {
            throw new Exception();
        }
        public override void CleanUp()
        {
            throw new Exception();
        }
    }
}
