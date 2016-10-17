using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HumanResources.MVC.Models;

namespace HumanResources.MVC.Authentication
{
    public interface IAuthenticate
    {
        bool Authenticate(string username, string password);
    }
}