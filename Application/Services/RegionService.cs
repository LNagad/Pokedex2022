using Application.Repositories;
using Application.ViewModels.PokemonType;
using Application.ViewModels.Region;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;

        public RegionService(ApplicationContext dbContext)
        {
            _regionRepository = new (dbContext); 
        }

        public async Task<List<RegionViewModel>> GetAllRegions()
        {
            var item = await _regionRepository.GetAllAsync();

            return item.Select(p => new RegionViewModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        public async Task<SaveRegionViewModel> GetRegionById(int id)
        {
            var result = await _regionRepository.GetByIdAsync(id);

            SaveRegionViewModel item = new();
            item.Id = result.Id;
            item.Name = result.Name;

            return item;
        }

        public async Task AddAsync(SaveRegionViewModel vm)
        {
            Region item = new();
            item.Id = vm.Id;
            item.Name = vm.Name;

            await _regionRepository.AddAsync(item);
        }

        public async Task UpdateAsync(SaveRegionViewModel vm)
        {
            var pokemonType = new Region()
            {
                Id = vm.Id,
                Name = vm.Name
            };

            await _regionRepository.UpdateAsync(pokemonType);

        }

        public async Task DeleteAsync(int id)
        {
            Region item = await _regionRepository.GetByIdAsync(id);

            await _regionRepository.DeleteAsync(item);

        }

    }
}
