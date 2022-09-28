
using Application.Services;
using Application.ViewModels.PokemonType;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonTypeController : Controller
    {
        private readonly PokemonTypeService _pokemonTypeService;          

        public PokemonTypeController(ApplicationContext dbContext)
        {
            _pokemonTypeService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonTypeService.GetAllPokemonTypes());
        }

        public IActionResult Create()
        {
            return View("SavePokemonType", new SavePokemonTypeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonTypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", vm);
            }

            await _pokemonTypeService.AddAsync(vm);

            return RedirectToRoute(new { controller = "PokemonType", action = "Index" } );
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SavePokemonType", await _pokemonTypeService.GetPokemonTypeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(SavePokemonTypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemonType", vm);
            }

            await _pokemonTypeService.UpdateAsync(vm);

            return RedirectToRoute(new { controller = "PokemonType", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _pokemonTypeService.GetPokemonTypeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(SavePokemonTypeViewModel vm)
        {
            await _pokemonTypeService.DeleteAsync(vm.Id);

            return RedirectToRoute(new { controller = "PokemonType", action = "Index" });
        }
    }
}
