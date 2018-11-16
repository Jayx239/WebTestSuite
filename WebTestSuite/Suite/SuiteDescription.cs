using System.Text;

namespace WebTestSuite.Suite
{
    public class SuiteDescription
    {
        public string SuiteName { get; set; }
        public string Client { get; set; }

        public SuiteDescription()
        {
            SuiteName = string.Empty;
            Client = string.Empty;
        }

        public SuiteDescription(string suiteName, string client)
        {
            SuiteName = suiteName;
            Client = client;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Suite: ").Append(SuiteName).Append("\nClient: ").Append(Client).Append("\n");
            return sb.ToString();
        }

    }
}
