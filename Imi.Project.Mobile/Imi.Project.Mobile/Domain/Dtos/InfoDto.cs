using System;
using System.Collections.ObjectModel;

namespace Imi.Project.Mobile.Domain.Dtos
{
    public class InfoDto
    {
        public Guid Id { get; set; }
        public string NameDutch { get; set; }

        public string NameFamily { get; set; }
        
        public Uri Image { get; set; }
        public int TempMax { get; set; }
        public int TempMin { get; set; }
        public int PhMax { get; set; }
        public int PhMin { get; set; }
        public int GhMin { get; set; }
        public int GhMax { get; set; }
        public BreedingDto Breeding { get; set; }
        public ContinentDto Continent { get; set; }
        public DietDto Diet { get; set; }
        public KindDto Kind { get; set; }
        public SocialDto Social { get; set; }
    }
}