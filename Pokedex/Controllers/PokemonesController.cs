using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
