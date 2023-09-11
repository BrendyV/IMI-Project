using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Imi.Project.Api.Core.Dtos.Request
{
    public class AnimalAddRequestDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string NameDutch { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string NameFamily { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int BreedingId { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int ContinentId { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int DietId { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int KindId { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int SocialId { get; set; }

        public IFormFile Image { get; set; }
        public int TempMax { get; set; }
        public int TempMin { get; set; }
        public int PhMax { get; set; }
        public int PhMin { get; set; }
        public int GhMax { get; set; }
        public int GhMin { get; set; }

    }
}
