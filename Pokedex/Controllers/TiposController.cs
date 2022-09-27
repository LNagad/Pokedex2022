using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class TiposController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
