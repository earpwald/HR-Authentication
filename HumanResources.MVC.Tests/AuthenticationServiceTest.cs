using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HumanResources.MVC.Authentication;

namespace HumanResources.Tests
{
    [TestClass]
    public class AuthenticationServiceTest
    {
        IAuthenticate authService = AuthenticationFactory.getAuthService();
        private const string CorrectUserName = "janderson";
        private const string WrongUserName = "wrong";
        private const string CorrectPassword = "pass";
        private const string WrongPassword = "test";

        [TestMethod]
        public void Authenticate_Success()
        {
            Assert.IsTrue(authService.Authenticate(CorrectUserName, CorrectPassword));
        }

        [TestMethod]
        public void Authenticate_WrongUserName()
        {
            Assert.IsFalse(authService.Authenticate(WrongUserName, CorrectPassword));
        }

        [TestMethod]
        public void Authenticate_WrongPassword()
        {
            Assert.IsFalse(authService.Authenticate(CorrectUserName, WrongPassword));
        }

        [TestMethod]
        public void Authenticate_WrongUserName_WrongPassword()
        {
            Assert.IsFalse(authService.Authenticate(WrongUserName, WrongPassword));
        }

        [TestMethod]
        public void Authenticate_BlankUserName_WrongPassword()
        {
            Assert.IsFalse(authService.Authenticate(String.Empty, CorrectPassword));
        }

        [TestMethod]
        public void Authenticate_CorrectUserName_BlankPassword()
        {
            Assert.IsFalse(authService.Authenticate(CorrectUserName, String.Empty));
        }

        [TestMethod]
        public void Authenticate_BlankUserName_BlankPassword()
        {
            Assert.IsFalse(authService.Authenticate(String.Empty, String.Empty));
        }
    }
}
