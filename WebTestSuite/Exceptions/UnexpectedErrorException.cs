namespace WebTestSuite.Exceptions
{
    public class UnexpectedErrorException : FailException
    {
        public UnexpectedErrorException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
