using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RaygunTrello.Models;
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
        public async Task<ActionResult> Index(string cardId, string userToken)
        {
            var comments = await _trelloService.GetCardCommentsAsync(userToken, cardId);
            var card = await _trelloService.GetCardAsync(userToken, cardId);

            ViewBag.UserToken = userToken;
            return View(new TrelloCardViewModel {Card = card, Comments = comments});
        }

        // POST: Card Comment
        [HttpPost]
        public async Task<ActionResult> Index(string comment, string cardId, string userToken)
        {
            await _trelloService.AddCommentToCardAsync(userToken, cardId, comment);
            return RedirectPermanent($"/Card?cardId={cardId}&userToken={userToken}");
        }

        public class TrelloCardViewModel
        {
            public TrelloCard Card { get; set; }
            public IEnumerable<TrelloComment> Comments { get; set; }
        }
    }
}