using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Response
{
    public class AnimalResponseDto : BaseResponseDto
    {
        public string NameFamily { get; set; }
        public string NameDutch { get; set; }
        public Uri Image { get; set; }
        public string Kind { get; set; }
        public string Continent { get; set; }
        public string Social { get; set; }
        public string Breeding { get; set; }
        public string Diet { get; set; }

        public int TempMax { get; set; }
        public int TempMin { get; set; }
        public int PhMax { get; set; }
        public int PhMin { get; set; }
        public int GhMax { get; set; }
        public int GhMin { get; set; }

    }
}
