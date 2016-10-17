using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResources.MVC.Models;
using HumanResources.MVC.Authentication;
using System.Web.Security;

namespace HumanResources.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
       
        // GET: /Authentication/
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: /Authentication/
        [HttpPost]
        public ActionResult Index(AuthenticationModel userDetails)
        {
            if (ModelState.IsValid)
            {
                IAuthenticate authenticationService = AuthenticationFactory.getAuthService();
                bool authenticated = authenticationService.Authenticate(userDetails.Username, userDetails.Password);

                if (authenticated)
                {
                    FormsAuthentication.SetAuthCookie(userDetails.Username, false);
                    
                    // Forward User to Application Home Page
                    return RedirectToAction("Index", "Home");
                }
            }

            // Forward user to Not Authenticated Alert page
            return View("NotAuthenticated");
        }
    }
}
