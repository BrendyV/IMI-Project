using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Imi.Project.Api.Core.Dtos.Request
{
    public class KindAddRequestDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }

        public IFormFile Image { get; set; }
    }
}