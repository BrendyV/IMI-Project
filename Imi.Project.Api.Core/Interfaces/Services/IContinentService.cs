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
    public interface IContinentService
    {
        Task<ItemResultModel<Continent>> GetAllAsync();
        Task<ItemResultModel<Continent>> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ItemResultModel<Continent>> Add(string name, IFormFile image);
        Task<ItemResultModel<Continent>> UpdateAsync(int id, string name);
    }
}
