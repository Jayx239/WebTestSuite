using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestSuite
{
    public interface IStateConfiguration
    {
        void SetUp();
        void CleanUp();
    }
}
