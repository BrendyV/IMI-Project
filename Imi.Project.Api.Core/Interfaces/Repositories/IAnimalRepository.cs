using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IAnimalRepository : IBaseRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetByBreedingIdAsync(int id);
        Task<IEnumerable<Animal>> GetByContinentIdAsync(int id);
        Task<IEnumerable<Animal>> GetByDietIdAsync(int id);
        Task<IEnumerable<Animal>> GetByKindIdAsync(int id);
        Task<IEnumerable<Animal>> GetBySocialIdAsync(int id);
    }
}
