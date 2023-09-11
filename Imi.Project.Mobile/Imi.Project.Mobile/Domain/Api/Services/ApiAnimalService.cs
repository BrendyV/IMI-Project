using Imi.Project.Mobile.Domain.Api.Interfaces;
using Imi.Project.Mobile.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Api.Services
{
    public class ApiAnimalService : IApiAnimalRepository
    {

        private readonly HttpClient _httpClient;

        public ApiAnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreateEditDto> AddAnimalAsync(CreateEditDto animal)
        {
            var addAnimal = await WebApiClient
                .PostCallApi<CreateEditDto, CreateEditDto>($"{Constants._baseUri}api/animals", animal);
            return addAnimal;
        }

        public async Task<CreateEditDto> DeleteAnimalAsync(Guid id)
        {
            return await WebApiClient
                .DeleteCallApi<CreateEditDto>($"{Constants._baseUri}api/animals/{id}");
        }

        public async Task<IEnumerable<AnimalDto>> GetAnimalsAsync()
        {
            var result = await WebApiClient
                .GetApiResult<IEnumerable<AnimalDto>>($"{Constants._baseUri}api/animals/");
            return result;
        }

        public async Task<InfoDto> GetAnimalAsync(Guid id)
        {
            return await WebApiClient
                .GetApiResult<InfoDto>($"{Constants._baseUri}api/animals/{id}");
        }

        public async Task<CreateEditDto> UpdateAnimalAsync(CreateEditDto animal)
        {
            return await WebApiClient
                .PutCallApi<CreateEditDto, CreateEditDto>($"{Constants._baseUri}api/animals/{animal.Id}", animal);
        }


    }
}
