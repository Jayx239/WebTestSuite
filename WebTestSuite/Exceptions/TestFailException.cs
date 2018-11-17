namespace WebTestSuite.Exceptions
{
    public class TestFailException : System.Exception
    {
        public TestFailException() : base() { }
        public TestFailException(string message) : base(message) { }
        public TestFailException(string message, System.Exception innerException) : base() { }
    }
}
