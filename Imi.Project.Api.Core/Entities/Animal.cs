using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Animal : BaseEntity
    {

        public string NameFamily { get; set; }
        public string NameDutch { get; set; }
        public Uri ImageUrl { get; set; }
        public string Image { get; set; }
        public Kind Kind { get; set; }
        public int KindId { get; set; }
        public Continent Continent { get; set; }
        public int ContinentId { get; set; }
        public Social Social { get; set; }
        public int SocialId { get; set; }
        public Breeding Breeding { get; set; }
        public int BreedingId { get; set; }
        public Diet Diet { get; set; }
        public int DietId { get; set; }

        public int TempMax { get; set; }
        public int TempMin { get; set; }
        public int PhMax { get; set; }
        public int PhMin { get; set; }
        public int GhMax { get; set; }
        public int GhMin { get; set; }
    }
}
