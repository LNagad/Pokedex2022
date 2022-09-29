using Application.ViewModels.PokemonType;
using Application.ViewModels.Region;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pokemon
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del pokemon")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la imagen del pokemon")]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una region")]
        public int RegionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar el tipo primario")]
        public int PrimaryTypeId { get; set; }
        public int? SecundaryTypeId { get; set; }

        public List<PokemonTypeViewModel>? PokemonTypes { get; set; }
        public List<RegionViewModel>? Regions { get; set; }
    }
}
