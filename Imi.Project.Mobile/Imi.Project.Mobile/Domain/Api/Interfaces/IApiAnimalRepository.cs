using Imi.Project.Mobile.Domain.Dtos;
using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Api.Interfaces
{
    public interface IApiAnimalRepository
    {
        Task<IEnumerable<AnimalDto>> GetAnimalsAsync();
        Task<InfoDto> GetAnimalAsync(Guid id);
        Task<CreateEditDto> AddAnimalAsync(CreateEditDto animal);
        Task<CreateEditDto> UpdateAnimalAsync(CreateEditDto animal);
        Task<CreateEditDto> DeleteAnimalAsync(Guid id);
    }
}