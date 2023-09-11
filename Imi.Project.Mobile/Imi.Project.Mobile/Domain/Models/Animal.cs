using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Mobile.Domain.Dtos;

namespace Imi.Project.Mobile.Domain.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string NameDutch { get; set; }
        public string NameFamily { get; set; }
        public Uri ImageUrl { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
        public int PhMin { get; set; }
        public int PhMax { get; set; }
        public int GhMin { get; set; }
        public int GhMax { get; set; }
        public ICollection<Breeding> Breedings { get; set; }
        public ICollection<Continent> Continents { get; set; }
        public ICollection<Diet> Diets { get; set; }
        public ICollection<Kind> Kinds { get; set; }
        public ICollection<Social> Socials { get; set; }
    }


}
