using System;

namespace WebTestSuite.Exceptions
{
    public class AttributeException : TestFailException
    {
        public AttributeException() : base("Attribute exception")
        {
        }

        public AttributeException(string message) : base(message)
        {
        }

        public AttributeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
