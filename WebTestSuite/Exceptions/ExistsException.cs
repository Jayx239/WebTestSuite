namespace WebTestSuite.Exceptions
{
    public class ExistsException : FailException
    {
        public ExistsException() : base()
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
