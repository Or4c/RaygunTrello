using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace RaygunTrello.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Token(string userToken)
        {
            // Check if user token is valid
            // If valid then redirect to /Board/Index
            // If not valid then redirect back to Home/Index with an error message
            return View();
        }
    }
}