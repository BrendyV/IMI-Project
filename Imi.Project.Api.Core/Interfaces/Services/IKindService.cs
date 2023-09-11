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
    public interface IKindService
    {
        Task<ItemResultModel<Kind>> GetAllAsync();
        Task<ItemResultModel<Kind>> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ItemResultModel<Kind>> Add(string name, IFormFile image);
        Task<ItemResultModel<Kind>> UpdateAsync(int id, string name);
    }
}
