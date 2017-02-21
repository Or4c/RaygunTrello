using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using RaygunTrello.Models;

namespace RaygunTrello.Controllers
{
    [HandleError]
    public class CardController : BaseController
    {
        public async Task<ActionResult> Index(string cardId, string userToken)
        {
            var validateResult = await ValidateToken(userToken);
            if (validateResult != null) return validateResult;

            var comments = await TrelloService.GetCardCommentsAsync(userToken, cardId);
            var card = await TrelloService.GetCardAsync(userToken, cardId);

            if (card == null) return new HttpNotFoundResult("Can't find a card matching that id");

            ViewBag.UserToken = userToken;
            return View(new TrelloCardViewModel {Card = card, Comments = comments});
        }

        [HttpPost]
        public async Task<ActionResult> Index(string comment, string cardId, string userToken)
        {
            var validateResult = await ValidateToken(userToken);
            if (validateResult != null) return validateResult;

            await TrelloService.AddCommentToCardAsync(userToken, cardId, comment);
            return RedirectPermanent($"/Card?cardId={cardId}&userToken={userToken}");
        }

        public class TrelloCardViewModel
        {
            public TrelloCard Card { get; set; }
            public IEnumerable<TrelloComment> Comments { get; set; }
        }
    }
}