using System.Threading.Tasks;
using System.Web.Mvc;

namespace RaygunTrello.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TokenError()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Token(string userToken)
        {
            var result = await ValidateToken(userToken);
            return result ?? RedirectPermanent($"/?userToken={userToken}");
        }
    }
}