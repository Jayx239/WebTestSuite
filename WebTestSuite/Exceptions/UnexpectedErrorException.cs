namespace WebTestSuite.Exceptions
{
    public class UnexpectedErrorException : TestFailException
    {
        public UnexpectedErrorException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
