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
    public interface IDietService
    {
        Task<ItemResultModel<Diet>> GetAllAsync();
        Task<ItemResultModel<Diet>> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ItemResultModel<Diet>> Add(string name);
        Task<ItemResultModel<Diet>> UpdateAsync(int id, string name);
    }
}
