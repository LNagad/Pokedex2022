using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int RegionId { get; set; }
        public int PrimaryTypeId { get; set; }
        public int? SecundaryTypeId { get; set; }

        //Navigation property
        public Region Region { get; set; }
        public PokemonType PrimaryType { get; set; }
        public PokemonType SecundaryType { get; set; }
    }
}
