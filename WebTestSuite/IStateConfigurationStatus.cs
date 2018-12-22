using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestSuite
{
    public interface IStateConfigurationStatus
    {
        /// <summary>
        /// Indicates whether setup operation executed
        /// </summary>
        bool IsSetUp { get; set; }
        /// <summary>
        /// Indicates whether cleanup operation executed
        /// </summary>
        bool IsCleanedUp { get; set; }
        /// <summary>
        /// Indicates whether setup was successful
        /// </summary>
        bool SetUpFailed { get; set; }
        /// <summary>
        /// Indicates whether cleanup completed successfully
        /// </summary>
        bool CleanUpFailed { get; set; }
        /// <summary>
        /// Determines whether setup cleanup is needed, will return true if cleanup is not executed and cleanup has not already failed
        /// </summary>
        bool ShouldCleanUp { get; }
    }
}
