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
    public interface ISocialService
    {
        Task<ItemResultModel<Social>> GetAllAsync();
        Task<ItemResultModel<Social>> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ItemResultModel<Social>> Add(string name);
        Task<ItemResultModel<Social>> UpdateAsync(int id, string name);
    }
}
