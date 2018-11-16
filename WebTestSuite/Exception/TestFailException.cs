namespace WebTestSuite.Exception
{
    public class TestFailException : System.Exception
    {
        public TestFailException() : base() { }
        public TestFailException(string message) : base(message) { }
    }
}
