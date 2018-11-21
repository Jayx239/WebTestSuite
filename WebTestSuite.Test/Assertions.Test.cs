using System;
using NUnit.Framework;
using WebTestSuite.Exceptions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebTestSuite.Test
{
    [TestFixture]
    public class Assertions
    {
        [Test]
        public void TestFailDefaultTest()
        {
            FailException exception = new FailException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.FailException' was thrown.");
        }
        [Test]
        public void TestFailMessageTest()
        {
            FailException exception = new FailException("Attribute Exception Messsage");
            Assert.AreEqual(exception.Message, "Attribute Exception Messsage");
        }
        [Test]
        public void TestFailInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            FailException exception = new FailException("Attribute Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "Attribute Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }

        [Test]
        public void TestAttributeDefaultTest ()
        {
            AttributeException exception = new AttributeException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.AttributeException' was thrown.");
        }
        [Test]
        public void TestAttributeMessageTest()
        {
            AttributeException exception = new AttributeException("Attribute Exception Messsage");
            Assert.AreEqual(exception.Message, "Attribute Exception Messsage");
        }
        [Test]
        public void TestAttributeInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            AttributeException exception = new AttributeException("Attribute Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "Attribute Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }

        [Test]
        public void TestExistsDefaultTest()
        {
            ExistsException exception = new ExistsException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.ExistsException' was thrown.");
        }
        [Test]
        public void TestExistsMessageTest()
        {
            ExistsException exception = new ExistsException("Exists Exception Messsage");
            Assert.AreEqual(exception.Message, "Exists Exception Messsage");
        }
        [Test]
        public void TestExistsInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            ExistsException exception = new ExistsException("Exists Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "Exists Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }

        [Test]
        public void TestMissMatchDefaultTest()
        {
            MissMatchException exception = new MissMatchException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.MissMatchException' was thrown.");
        }
        [Test]
        public void TestMissMatchMessageTest()
        {
            MissMatchException exception = new MissMatchException("MissMatch Exception Messsage");
            Assert.AreEqual(exception.Message, "MissMatch Exception Messsage");
        }
        [Test]
        public void TestMissMatchInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            MissMatchException exception = new MissMatchException("MissMatch Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "MissMatch Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }
        [Test]
        public void TestMissMatchObjectTest()
        {
            MissMatchException exception = new MissMatchException("first","second");
            Assert.AreEqual(exception.Message, "Expected: \"" + "first" + "\", Actual: \"" + "second" + "\"");
        }
        [Test]
        public void TestMissMatchPremessageTest()
        {
            Exception innerException = new Exception("Inner exception");
            MissMatchException exception = new MissMatchException("first", "second", "Items did not match");
            Assert.AreEqual(exception.Message, "Items did not match" + " - Expected: \"" + "first" + "\", Actual: \"" + "second" + "\"");
        }
        
        [Test]
        public void TestPropertyDefaultTest()
        {
            PropertyException exception = new PropertyException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.PropertyException' was thrown.");
        }
        [Test]
        public void TestPropertyMessageTest()
        {
            PropertyException exception = new PropertyException("Property Exception Messsage");
            Assert.AreEqual(exception.Message, "Property Exception Messsage");
        }
        [Test]
        public void TestPropertyInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            PropertyException exception = new PropertyException("Property Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "Property Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }

        [Test]
        public void TestSuiteFailDefaultTest()
        {
            SuiteFailException exception = new SuiteFailException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.SuiteFailException' was thrown.");
        }
        [Test]
        public void TestSuiteFailMessageTest()
        {
            SuiteFailException exception = new SuiteFailException("SuiteFail Exception Messsage");
            Assert.AreEqual(exception.Message, "SuiteFail Exception Messsage");
        }
        [Test]
        public void TestSuiteFailInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            SuiteFailException exception = new SuiteFailException("SuiteFail Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "SuiteFail Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }
        //
        [Test]
        public void TestUnexpectedErrorDefaultTest()
        {
            UnexpectedErrorException exception = new UnexpectedErrorException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.UnexpectedErrorException' was thrown.");
        }
        [Test]
        public void TestUnexpectedErrorMessageTest()
        {
            UnexpectedErrorException exception = new UnexpectedErrorException("UnexpectedError Exception Messsage");
            Assert.AreEqual(exception.Message, "UnexpectedError Exception Messsage");
        }
        [Test]
        public void TestUnexpectedErrorInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            UnexpectedErrorException exception = new UnexpectedErrorException("UnexpectedError Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "UnexpectedError Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }

        [Test]
        public void TestVisibleDefaultTest()
        {
            VisibleException exception = new VisibleException();
            Assert.AreEqual(exception.Message, "Exception of type 'WebTestSuite.Exceptions.VisibleException' was thrown.");
        }
        [Test]
        public void TestVisibleMessageTest()
        {
            VisibleException exception = new VisibleException("Visible Exception Messsage");
            Assert.AreEqual(exception.Message, "Visible Exception Messsage");
        }
        [Test]
        public void TestVisibleInnerExceptionTest()
        {
            Exception innerException = new Exception("Inner exception");
            VisibleException exception = new VisibleException("Visible Exception Messsage", innerException);
            Assert.AreEqual(exception.Message, "Visible Exception Messsage");
            Assert.AreEqual(exception.InnerException, innerException);
        }
    }
}
