using System.Collections;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class Breeding : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}