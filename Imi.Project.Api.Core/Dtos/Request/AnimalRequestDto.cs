using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Request
{
    public class AnimalRequestDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string NameDutch { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string NameFamily { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid BreedingId { get; set; }
        public string BreedingName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid ContinentId { get; set; }
        public string ContinentName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid DietId { get; set; }
        public string DietName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid KindId { get; set; }
        public string KindName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Guid SocialId { get; set; }
        public string SocialName { get; set; }

        public Uri ImageUrl { get; set; }
        public int TempMax { get; set; }
        public int TempMin { get; set; }
        public int PhMax { get; set; }
        public int PhMin { get; set; }
        public int GhMax { get; set; }
        public int GhMin { get; set; }

    }
}
