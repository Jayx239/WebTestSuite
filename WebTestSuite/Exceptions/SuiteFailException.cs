using System;
namespace WebTestSuite.Exceptions
{
    public class SuiteFailException : FailException
    {
        public SuiteFailException() : base("Suit failed")
        {
        }

        public SuiteFailException(string message) : base(message)
        {
        }

        public SuiteFailException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
