using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IBreedingService
    {
        Task<ItemResultModel<Breeding>> GetAllAsync();
        Task<ItemResultModel<Breeding>> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ItemResultModel<Breeding>> Add(string name);
        Task<ItemResultModel<Breeding>> UpdateAsync(int id, string name);
    }
}
