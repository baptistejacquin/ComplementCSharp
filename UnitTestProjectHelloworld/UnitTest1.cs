using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helloworld;

namespace UnitTestProjectHelloworld
{
    [TestClass]
    public class UnitTest1
    {
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
        public void TestGetHelloMessageForBonnaAprem()
        {
            FakeTime fake = new FakeTime();
            fake.DateTimeToReturn = new DateTime(2018, 08, 21, 13, 00, 25);
            Message message = new Message(fake, 9, 13, 18);
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
        public void TestGetHelloMessageForBonWE()
        {
            FakeTime fake = new FakeTime();
            fake.DateTimeToReturn = new DateTime(2018, 08, 19, 18, 00, 25);
            Message message = new Message(fake, 9, 13, 18);
            string result = message.GetHelloMessage();
            Assert.AreEqual("Bon week-end " + Environment.UserName, result);
            Assert.IsTrue(result.Contains("Bon week-end"));
        }
    }
}
