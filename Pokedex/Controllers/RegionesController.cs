using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class RegionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
