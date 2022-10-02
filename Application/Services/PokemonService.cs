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
                SecundaryType = p.SecundaryType == null ? "" : p.SecundaryType.Name,
                RegionId = p.RegionId
            }).ToList();
        }

        public async Task<List<PokemonViewModel>> GetAllPokemonWithFilters(FilterPokemonViewModel filters)
        {
            var properties = new List<string> { "Region", "PrimaryType", "SecundaryType" };

            var item = await _pokemonRepository.GetAllWithIncludeAsync(properties);

            var itemList = item.Select(p => new PokemonViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Region = p.Region.Name,
                PrimaryType = p.PrimaryType.Name,
                SecundaryType = p.SecundaryType == null ? "" : p.SecundaryType.Name,
                RegionId = p.RegionId,

            }).ToList();

            if (filters.RegionId != null)
            {
                itemList = itemList.Where(pokemon => pokemon.RegionId == filters.RegionId.Value).ToList();
            }

            if (filters.PokemonName != null)
            {
                itemList = itemList.Where(p => p.Name.ToLower()
                .Contains(filters.PokemonName.ToLower())).ToList();
            }

            return itemList;
        }


        public async Task<SavePokemonViewModel> GetPokemonById(int id)
        {
            var result = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel item = new();
            item.Id = result.Id;
            item.Name = result.Name;
            item.ImageUrl = result.ImageUrl;
            item.RegionId = result.RegionId;
            item.PrimaryTypeId = result.PrimaryTypeId;
            item.SecundaryTypeId = result.SecundaryTypeId == null ? 0 : result.SecundaryTypeId;

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

        public async Task UpdateAsync(SavePokemonViewModel vm)
        {
            var pokemon = new Pokemon()
            {
                Id = vm.Id,
                Name = vm.Name,
                ImageUrl = vm.ImageUrl,
                RegionId = vm.RegionId,
                PrimaryTypeId = vm.PrimaryTypeId,
                SecundaryTypeId = vm.SecundaryTypeId
            };

            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task DeleteAsync(int id)
        {
            Pokemon item = await _pokemonRepository.GetByIdAsync(id);

            await _pokemonRepository.DeleteAsync(item);

        }

    }
}
