using Microsoft.AspNetCore.Mvc;

namespace APS.Cronicos.UI.Web.Areas.AvaliacaoRisco.Controllers
{
    public class RelatorioAvaliacoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
