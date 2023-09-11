using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(AnimalDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Animal>> GetByBreedingIdAsync(int id)
        {
            return await _table
                .Include(b => b.Breeding)
                .Where(b => b.BreedingId == id).ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetByContinentIdAsync(int id)
        {
            return await _table
                .Include(b => b.Continent)
                .Where(b => b.ContinentId == id).ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetByDietIdAsync(int id)
        {
            return await _table
                .Include(d => d.Diet)
                .Where(d => d.DietId == id).ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetByKindIdAsync(int id)
        {
            return await _table
                .Include(k => k.Kind)
                .Where(k => k.KindId == id).ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetBySocialIdAsync(int id)
        {
            return await _table
                .Include(s => s.Breeding)
                .Where(s => s.SocialId == id).ToListAsync();
        }

        public override async Task<Animal> GetByIdAsync(int id)
        {
            return await _table
                .Include(a => a.Breeding)
                .Include(a => a.Continent)
                .Include(a => a.Diet)
                .Include(a => a.Kind)
                .Include(a => a.Social)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _table
                .Include(a => a.Breeding)
                .Include(a => a.Continent)
                .Include(a => a.Diet)
                .Include(a => a.Kind)
                .Include(a => a.Social)
                .ToListAsync();
        }
    }
}
