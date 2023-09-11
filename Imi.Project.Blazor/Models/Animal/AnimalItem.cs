using System;

namespace Imi.Project.Blazor.Models.Animal
{
    public class AnimalItem
    {
        public int Id { get; set; }
        public string NameFamily { get; set; }
        public string NameDutch { get; set; }
        public Uri Image { get; set; }
        public InputSelectItem[] Kinds { get; set; }
        public string KindId { get; set; }
        public InputSelectItem[] Diets { get; set; }
        public string DietId { get; set; }
        public InputSelectItem[] Continents { get; set; }
        public string ContinentId { get; set; }
        public InputSelectItem[] Socials { get; set; }
        public string SocialId { get; set; }
        public InputSelectItem[] Breedings { get; set; }
        public string BreedingId { get; set; }
        public decimal minTemp { get; set; }
        public decimal maxTemp { get; set; }
        public decimal minPh { get; set; }
        public decimal maxPh { get; set; }
        public decimal minGh { get; set; }
        public decimal maxGh { get; set; }

    }
}
