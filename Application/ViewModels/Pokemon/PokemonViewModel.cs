﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pokemon
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        
        public string Region { get; set; }
        public string PrimaryType { get; set; }
        public string SecundaryType { get; set; }
    }
}
