using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResources.MVC.Authentication
{
    public class AuthenticationFactory
    {
        public static IAuthenticate getAuthService()
        {
            return new AuthenticationService();
        }
    }
}