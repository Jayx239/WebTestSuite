using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestSuite
{
    public interface ISuccessIndicator
    {
        bool Sucessful { get; }
    }
}
