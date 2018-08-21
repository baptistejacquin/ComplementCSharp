using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helloworld;
using NMock;

namespace UnitTestProjectHelloworld
{
    [TestClass]
    public class UnitTest1
    {
        private MockFactory _mockFactory;
        private Mock<ITime> _mockITime;

        [TestInitialize]
        public void Setup()
        {
            _mockFactory = new MockFactory();
            _mockITime = _mockFactory.CreateMock<ITime>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockFactory.VerifyAllExpectationsHaveBeenMet();
            _mockFactory.Dispose();
        }

        [TestMethod]
        public void TestGetHelloMessageForBonjour()
        {
            FakeTime fake = new FakeTime();
            fake.DateTimeToReturn = new DateTime(2018,08,21,9,00,25);
            Message message = new Message(fake,9,13,18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bonjour " + Environment.UserName, result);
        }

        [TestMethod]
        public void TestMockGetHelloMessageForBonjour()
        {
            _mockITime.Expects.One.GetProperty(_=>_.date).WillReturn(new DateTime(2018, 08, 21, 9, 00, 25));
            Message message = new Message(_mockITime.MockObject, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bonjour " + Environment.UserName, result);
        }

        [TestMethod]
        public void TestGetHelloMessageForBonnaAprem()
        {
            FakeTime fake = new FakeTime();
            fake.DateTimeToReturn = new DateTime(2018, 08, 21, 13, 00, 25);
            Message message = new Message(fake, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bon après-midi " + Environment.UserName, result);

        }

        [TestMethod]
        public void TestMockGetHelloMessageForBonnaAprem()
        {
            _mockITime.Expects.One.GetProperty(_ => _.date).WillReturn(new DateTime(2018, 08, 21, 13, 00, 25));
            Message message = new Message(_mockITime.MockObject, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bon après-midi " + Environment.UserName, result);
        }

        [TestMethod]
        public void TestGetHelloMessageForBonsoir()
        {
            FakeTime fake = new FakeTime();
            fake.DateTimeToReturn = new DateTime(2018, 08, 21, 18, 00, 25);
            Message message = new Message(fake, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bonsoir " + Environment.UserName, result);

        }

        [TestMethod]
        public void TestMockGetHelloMessageForBonsoir()
        {
            _mockITime.Expects.One.GetProperty(_ => _.date).WillReturn(new DateTime(2018, 08, 21, 18, 00, 25));
            Message message = new Message(_mockITime.MockObject, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bonsoir " + Environment.UserName, result);

        }

        [TestMethod]
        public void TestGetHelloMessageForBonWE()
        {
            FakeTime fake = new FakeTime();
            fake.DateTimeToReturn = new DateTime(2018, 08, 19, 18, 00, 25);
            Message message = new Message(fake, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bon week-end " + Environment.UserName, result);
            Assert.IsTrue(result.Contains("Bon week-end"));
        }

        [TestMethod]
        public void TestMockGetHelloMessageForBonWE()
        {
            _mockITime.Expects.One.GetProperty(_ => _.date).WillReturn(new DateTime(2018, 08, 19, 18, 00, 25));
            Message message = new Message(_mockITime.MockObject, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bon week-end " + Environment.UserName, result);
            Assert.IsTrue(result.Contains("Bon week-end"));
        }
    }
}
