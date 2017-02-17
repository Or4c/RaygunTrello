using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using RaygunTrello.Services;

namespace RaygunTrello.Controllers
{
    public class HomeController : Controller
    {

        private ITrelloService _trelloService;


        public HomeController()
        {
            _trelloService = ServiceLocator.GetService<ITrelloService>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Token(string userToken)
        {
            // Check if user token is valid
            //var tokenValidateResult = await _trelloService.ValidateUserTokenAsync(userToken);

            // If valid then redirect to /Board/Index
            // If not valid then redirect back to Home/Index with an error message
            return RedirectPermanent($"/?userToken={userToken}");
        }
    }
}