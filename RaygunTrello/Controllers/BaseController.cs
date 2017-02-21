using System.Threading.Tasks;
using System.Web.Mvc;
using RaygunTrello.Models;
using RaygunTrello.Services;

namespace RaygunTrello.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ITrelloRepository TrelloRepository;

        public BaseController()
        {
            TrelloRepository = ServiceLocator.GetService<ITrelloRepository>();
        }

        public async Task<ActionResult> ValidateToken(string token)
        {
            var validToken = await TrelloRepository.ValidateUserTokenAsync(token);
            return !validToken ? RedirectPermanent("/Home/TokenError") : null;
        }
    }
}