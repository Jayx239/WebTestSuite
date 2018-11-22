using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestSuite
{
    public interface IBreakable
    {
        bool BreakOnFail { get; set; }
    }
}
