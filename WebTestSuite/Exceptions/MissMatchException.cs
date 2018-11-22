using System;

namespace WebTestSuite.Exceptions
{
    public class MissMatchException : FailException
    {
        public MissMatchException()
        {
        }

        public MissMatchException(string message) : base(message)
        {
        }

        public MissMatchException(object expected, object actual):base("Expected: \""+ expected.ToString() + "\", Actual: \"" + actual.ToString() + "\"")
        {
        }

        public MissMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public MissMatchException(object expected, object actual, string preMessage) : base(preMessage + " - Expected: \"" + expected.ToString() + "\", Actual: \"" + actual.ToString() + "\"")
        {
        }
    }
}
