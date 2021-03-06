﻿using OpenQA.Selenium.Chrome;
using WebTestSuite.Suite;

namespace WebSuiteTest.Test.SampleTestSuite
{
    public class SampleSuite : TestSuite
    {
        public SampleSuite() : base()
        {
            this.SuiteDescription.Description = "Sample";
            this.SuiteDescription.SuiteName = "Sample tests";
            this.Tests.Add(new SampleTestFail(new ChromeDriver()));
            this.Tests.Add(new SampleTestPass(new ChromeDriver()));
        }
    }
}
