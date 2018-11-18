namespace WebTestSuite.Exceptions
{
    public class VisibleException : FailException
    {
        public VisibleException(): base("Item is not visible")
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
