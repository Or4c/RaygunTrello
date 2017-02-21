using System.Threading.Tasks;
using System.Web.Mvc;

namespace RaygunTrello.Controllers
{
    [HandleError]
    public class BoardController : BaseController
    {
        
        public async Task<ActionResult> Index(string userToken)
        {
            var validateResult = await ValidateToken(userToken);
            if (validateResult != null) return validateResult;

            var boards = await TrelloService.GetUserBoardsAsync(userToken);
            ViewBag.UserToken = userToken;
            return View(boards);
        }

        public async Task<ActionResult> Cards(string boardId, string userToken)
        {
            var validateResult = await ValidateToken(userToken);
            if (validateResult != null) return validateResult;

            var cards = await TrelloService.GetCardsForBoardAsync(userToken, boardId);
            if(cards == null) return new HttpNotFoundResult("Cannot find a board matching that id");

            ViewBag.UserToken = userToken;
            return View(cards);
        }

    }
}