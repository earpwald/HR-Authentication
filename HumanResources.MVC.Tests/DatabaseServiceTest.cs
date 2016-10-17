using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HumanResources.Data;

namespace HumanResources.Tests
{
    [TestClass]
    public class DatabaseServiceTest
    {
        IHumanResourcesDB dbService = DatabaseServiceFactory.getDatabaseService();
        private const string CorrectUserName = "janderson";
        private const string WrongUserName = "wrong";
        private const string CorrectPassword = "pass";
        private const string WrongPassword = "test";

        /*[TestMethod]
        public void VerifyUserPassword_Success()
        {
            Assert.IsTrue(dbService.VerifyUserPassword(CorrectUserName, CorrectPassword));
        }

        [TestMethod]
        public void VerifyUserPassword_WrongUsername()
        {
            Assert.IsFalse(dbService.VerifyUserPassword(WrongUserName, CorrectPassword));
        }

        [TestMethod]
        public void VerifyUserPassword_BlankUsername()
        {
            Assert.IsFalse(dbService.VerifyUserPassword(string.Empty, CorrectPassword));
        }

        [TestMethod]
        public void VerifyUserPassword_WrongPassword()
        {
            Assert.IsFalse(dbService.VerifyUserPassword(CorrectUserName, WrongPassword));
        }

        [TestMethod]
        public void VerifyUserPassword_BlankPassword()
        {
            Assert.IsFalse(dbService.VerifyUserPassword(CorrectUserName, string.Empty));
        }

        [TestMethod]
        public void VerifyUserPassword_BlankUsername_BlankPassword()
        {
            Assert.IsFalse(dbService.VerifyUserPassword(string.Empty, string.Empty));
        }*/
    }
}
