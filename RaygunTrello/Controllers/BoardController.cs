using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaygunTrello.Services;

namespace RaygunTrello.Controllers
{
    public class BoardController : Controller
    {
        private ITrelloService _trelloService;

        public BoardController()
        {
            _trelloService = ServiceLocator.GetService<ITrelloService>();
        }
        
        // GET: Board
        public ActionResult Index()
        {
            // Get a list of all boards for the user
            return View();
        }
    }
}