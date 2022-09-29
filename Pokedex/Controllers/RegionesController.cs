using Application.Services;
using Application.ViewModels.Region;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class RegionesController : Controller
    {
        private readonly RegionService _regionSerivce;

        public RegionesController(ApplicationContext dbContext)
        {
            _regionSerivce = new (dbContext);
        }

        public async Task <IActionResult> Index()
        {
            return View(await _regionSerivce.GetAllRegions());
        }

        public async Task <IActionResult> Create()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await _regionSerivce.AddAsync(vm);

            return RedirectToRoute(new { controller = "Regiones", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionSerivce.GetRegionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await _regionSerivce.UpdateAsync(vm);

            return RedirectToRoute(new { controller = "Regiones", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _regionSerivce.GetRegionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SaveRegionViewModel vm)
        {

            await _regionSerivce.DeleteAsync(vm.Id);

            return RedirectToRoute(new { controller = "Regiones", action = "Index" });
        }

    }
}
