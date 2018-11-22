namespace WebTestSuite.Exceptions
{
    public class FailException : System.Exception
    {
        public FailException() : base() { }
        public FailException(string message) : base(message) { }
        public FailException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
