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
            // Validate user token (maybe as filter)
            // TODO: user token validation
            var boards = await _trelloService.GetUserBoardsAsync(userToken);
            
            // Get a list of all boards for the user
            return View();
        }
    }
}