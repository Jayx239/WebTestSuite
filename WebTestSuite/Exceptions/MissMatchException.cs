namespace WebTestSuite.Exceptions
{
    public class MissMatchException : FailException
    {
        public MissMatchException(object expected, object actual):base("Expected: \""+ expected.ToString() + "\", Actual: \"" + actual.ToString() + "\"")
        {
        }
        public MissMatchException(object expected, object actual, string preMessage) : base(preMessage + " - Expected: \"" + expected.ToString() + "\", Actual: \"" + actual.ToString() + "\"")
        {
        }
    }
}
