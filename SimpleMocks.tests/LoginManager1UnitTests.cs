using MyBillingProduct;
using NUnit.Framework;

namespace SimpleMocks.tests
{
    [TestFixture]
    public class LoginManager1UnitTests
    {
        [TestCase("abc", "abc", "login ok: user: abc")]
        [TestCase("abcd", "abcd", "login ok: user: abcd")]
        public void IsLoginOK_WithExistingUser_CallLogger(string username, string password, string expectedMessage)
        {
            FakeLogger stubLogger = new FakeLogger();
            LoginManager1 loginManager1 = new LoginManager1(stubLogger);
            loginManager1.AddUser(username, password);

            bool logingResult = loginManager1.IsLoginOK(username, password);

            Assert.AreEqual(expectedMessage, stubLogger.Written);
        }

        [TestCase("abc", "abc", "bad login: abc,abc")]
        [TestCase("abcd", "abcd", "bad login: abcd,abcd")]
        public void IsLoginOK_WithNonExistingUser_CallLogger(string username, string password, string expectedMessage)
        {
            FakeLogger stubLogger = new FakeLogger();
            LoginManager1 loginManager1 = new LoginManager1(stubLogger);

            bool logingResult = loginManager1.IsLoginOK(username, password);

            Assert.AreEqual(expectedMessage, stubLogger.Written);
        }
    }

    public class FakeLogger : ILogger
    {
        public void Write(string text)
        {
            Written = text;
        }

        public string Written { get; private set; }
    }
}