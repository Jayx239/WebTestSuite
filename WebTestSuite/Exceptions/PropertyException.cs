namespace WebTestSuite.Exceptions
{
    public class PropertyException : FailException
    {
        public PropertyException() : base("Property exception")
        {
        }

        public PropertyException(string message) : base(message)
        {
        }

        public PropertyException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
