using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class PokemonTypeRepository : GenericRepository<PokemonType>
    {
        private readonly ApplicationContext _dbContext;
        public PokemonTypeRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
