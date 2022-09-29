using Application.Services;
using Application.ViewModels.Pokemon;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonesController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly PokemonTypeService _pokemonTypeService;
        private readonly RegionService _regionService;

        public PokemonesController(ApplicationContext dbContext)
        {
            _pokemonService = new (dbContext);
            _pokemonTypeService = new (dbContext);
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllPokemons());
        }

        public async Task<IActionResult> Create()
        {
            var vm = new SavePokemonViewModel();
            vm.PokemonTypes = await _pokemonTypeService.GetAllPokemonTypes();
            vm.Regions = await _regionService.GetAllRegions();

            return View("SavePokemon", vm);
        }
        [HttpPost]

        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                vm.PokemonTypes = await _pokemonTypeService.GetAllPokemonTypes();
                vm.Regions = await _regionService.GetAllRegions();
                return View("SavePokemon", vm);
            }
            
            await _pokemonService.AddAsync(vm);

            return RedirectToRoute(new { controller = "Pokemones", action = "Index" });
        }
    }
}
