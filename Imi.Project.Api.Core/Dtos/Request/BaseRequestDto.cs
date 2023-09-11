using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos.Request
{
    public class BaseRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
    }
}