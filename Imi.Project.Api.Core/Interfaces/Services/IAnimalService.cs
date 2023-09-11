using Imi.Project.Api.Core.Dtos.Request;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IAnimalService
    {
        Task<ItemResultModel<Animal>> GetAllAsync();
        Task<ItemResultModel<Animal>> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ItemResultModel<Animal>> Add(string nameDutch, string nameFamily, IFormFile image, int kindId, int breedingId, int dietId, int continentId, int socialId, int tempMin, int tempMax, int phMin, int phMax, int ghMin, int ghMax);
        Task<ItemResultModel<Animal>> UpdateAsync(int id, string nameDutch, string nameFamily, int kindId, int breedingId, int dietId, 
            int continentId, int socialId, int tempMin, int tempMax, int phMin, int phMax, int ghMin, int ghMax);
        
        Task<ItemResultModel<Animal>> GetByBreedingIdAsync(int id);
        Task<ItemResultModel<Animal>> GetByContinentIdAsync(int id);
        Task<ItemResultModel<Animal>> GetByDietIdAsync(int id);
        Task<ItemResultModel<Animal>> GetByKindIdAsync(int id);
        Task<ItemResultModel<Animal>> GetBySocialIdAsync(int id);
    }
}
