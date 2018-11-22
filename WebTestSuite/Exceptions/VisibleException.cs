namespace WebTestSuite.Exceptions
{
    public class VisibleException : FailException
    {
        public VisibleException(): base()
        {
        }

        public VisibleException(string message) : base(message)
        {
        }

        public VisibleException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
