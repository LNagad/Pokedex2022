using Application.Repositories;
using Application.ViewModels.PokemonType;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonTypeService
    {
        private readonly PokemonTypeRepository _pokemonTypeRepo;
        public PokemonTypeService(ApplicationContext dbContext)
        {
            _pokemonTypeRepo = new(dbContext);
        }

        public async Task<List<PokemonTypeViewModel>> GetAllPokemonTypes()
        {
            var item = await _pokemonTypeRepo.GetAllAsync();

            return item.Select(p => new PokemonTypeViewModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList(); 
        }

        public async Task<SavePokemonTypeViewModel> GetPokemonTypeById(int id)
        {
            var result = await _pokemonTypeRepo.GetByIdAsync(id);

            SavePokemonTypeViewModel item = new();
            item.Id = result.Id;
            item.Name = result.Name;

            return item;
        }

        public async Task AddAsync(SavePokemonTypeViewModel vm)
        {
            PokemonType item = new();
            item.Id = vm.Id;
            item.Name = vm.Name;

            await _pokemonTypeRepo.AddAsync(item);
        }

        public async Task UpdateAsync(SavePokemonTypeViewModel vm)
        {
            var pokemonType = new PokemonType()
            {
                Id = vm.Id,
                Name = vm.Name
            };

            await _pokemonTypeRepo.UpdateAsync(pokemonType);

        }

        public async Task DeleteAsync(int id)
        {
            PokemonType item = await _pokemonTypeRepo.GetByIdAsync(id);

            await _pokemonTypeRepo.DeleteAsync(item);

        }
    }
}
