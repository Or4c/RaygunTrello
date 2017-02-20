using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RaygunTrello.Services;

namespace RaygunTrello.Controllers
{
    public class CardController : Controller
    {
        private readonly ITrelloService _trelloService;

        public CardController()
        {
            _trelloService = ServiceLocator.GetService<ITrelloService>();
        }

        // GET: Card Comments
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}