using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RaygunTrello.Services;

namespace RaygunTrello.Controllers
{
    public class BoardController : Controller
    {
        private readonly ITrelloService _trelloService;

        public BoardController()
        {
            _trelloService = ServiceLocator.GetService<ITrelloService>();
        }
        
        // GET: Boards
        public async Task<ActionResult> Index(string userToken)
        {
            var boards = await _trelloService.GetUserBoardsAsync(userToken);
            ViewBag.UserToken = userToken;
            return View(boards);
        }

        // GET: Cards
        public async Task<ActionResult> Cards(string boardId, string userToken)
        {
            var cards = await _trelloService.GetCardsForBoardAsync(userToken, boardId);
            ViewBag.UserToken = userToken;
            return View(cards);
        }

    }
}