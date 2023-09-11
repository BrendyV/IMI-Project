using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class Kind : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Uri ImageUrl { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}