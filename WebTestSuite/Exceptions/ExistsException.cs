namespace WebTestSuite.Exceptions
{
    public class ExistsException : TestFailException
    {
        public ExistsException() : base("Item does not exist")
        {
        }

        public ExistsException(string message) : base(message)
        {
        }

        public ExistsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
