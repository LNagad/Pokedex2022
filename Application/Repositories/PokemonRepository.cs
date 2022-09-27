using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class PokemonRepository : GenericRepository<Pokemon>
    {
        private readonly ApplicationContext _dbContext;
        public PokemonRepository (ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
