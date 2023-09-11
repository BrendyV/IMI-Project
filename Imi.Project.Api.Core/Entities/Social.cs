using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class Social : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}