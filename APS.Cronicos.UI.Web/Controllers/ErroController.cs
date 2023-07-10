using Microsoft.AspNetCore.Mvc;

namespace APS.Cronicos.UI.Web.Controllers
{
    public class ErroController : BaseController
    {
        public ErroController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}