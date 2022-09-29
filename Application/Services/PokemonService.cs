using Application.Repositories;
using Application.ViewModels.Pokemon;
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
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;

        public PokemonService(ApplicationContext dbContext)
        {
            _pokemonRepository = new(dbContext);
        }


        public async Task<List<PokemonViewModel>> GetAllPokemons()
        {
            var properties = new List<string> { "Region", "PrimaryType", "SecundaryType" };

            var item = await _pokemonRepository.GetAllWithIncludeAsync(properties);

            return item.Select(p => new PokemonViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Region = p.Region.Name,
                PrimaryType = p.PrimaryType.Name,
                SecundaryType = p.SecundaryType == null ? "" : p.SecundaryType.Name

            }).ToList();
        }

        public async Task<SavePokemonViewModel> GetRegionById(int id)
        {
            var result = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel item = new();
            item.Id = result.Id;
            item.Name = result.Name;
            item.ImageUrl = result.ImageUrl;
            item.RegionId = result.RegionId;
            item.PrimaryTypeId = result.PrimaryTypeId;
            item.SecundaryTypeId = result.SecundaryTypeId;

            return item;
        }

        public async Task AddAsync(SavePokemonViewModel vm)
        {
            Pokemon item = new();
            item.Id = vm.Id;
            item.Name = vm.Name;
            item.ImageUrl = vm.ImageUrl;
            item.RegionId = vm.RegionId;
            item.PrimaryTypeId = vm.PrimaryTypeId;
            item.SecundaryTypeId = vm.SecundaryTypeId == null || vm.SecundaryTypeId == 0 ? null: vm.SecundaryTypeId;

            await _pokemonRepository.AddAsync(item);
        }

        //public async Task UpdateAsync(SaveRegionViewModel vm)
        //{
        //    var pokemonType = new Region()
        //    {
        //        Id = vm.Id,
        //        Name = vm.Name
        //    };

        //    await _regionRepository.UpdateAsync(pokemonType);
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    Region item = await _regionRepository.GetByIdAsync(id);

        //    await _regionRepository.DeleteAsync(item);

        //}

    }
}
