namespace WebTestSuite.Exceptions
{
    public class UnexpectedErrorException : FailException
    {
        public UnexpectedErrorException() : base()
        {
        }

        public UnexpectedErrorException(string message) : base(message)
        {
        }

        public UnexpectedErrorException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
