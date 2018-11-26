using System.Text;

namespace WebTestSuite.Suite
{
    /// <summary>
    /// Description of suite
    /// </summary>
    public class SuiteDescription
    {
        /// <summary>
        /// Name of suite
        /// </summary>
        public string SuiteName { get; set; }
        /// <summary>
        /// Short description of suite
        /// </summary>
        public string Description { get; set; }

        public SuiteDescription()
        {
            SuiteName = string.Empty;
            Description = string.Empty;
        }

        public SuiteDescription(string suiteName, string description)
        {
            SuiteName = suiteName;
            Description = description;
        }

        /// <summary>
        /// Creates string representation of description details
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Suite: ").Append(SuiteName).Append("\nClient: ").Append(Description).Append("\n");
            return sb.ToString();
        }

    }
}
