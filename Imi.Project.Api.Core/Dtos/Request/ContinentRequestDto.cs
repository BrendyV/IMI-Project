using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Request
{
    public class ContinentRequestDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        public Uri Image { get; set; }
    }
}
