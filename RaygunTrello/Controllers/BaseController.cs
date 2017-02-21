using System.Threading.Tasks;
using System.Web.Mvc;
using RaygunTrello.Services;

namespace RaygunTrello.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ITrelloService TrelloService;

        public BaseController()
        {
            TrelloService = ServiceLocator.GetService<ITrelloService>();
        }

        public async Task<ActionResult> ValidateToken(string token)
        {
            var validToken = await TrelloService.ValidateUserTokenAsync(token);
            return !validToken ? RedirectPermanent("/Home/TokenError") : null;
        }
    }
}