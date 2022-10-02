using Application.Services;
using Application.ViewModels.Pokemon;
using Database;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index(FilterPokemonViewModel filters)
        {
            ViewBag.regions = await _regionService.GetAllRegions();
            ViewBag.pokemonName = filters.PokemonName;
            return View(await _pokemonService.GetAllPokemonWithFilters(filters));
        }

    }
}