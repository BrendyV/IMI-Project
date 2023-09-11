using Imi.Project.Blazor.Models.Animal;
using Imi.Project.Blazor.Services.Animal.Api;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Animal.Api
{
    public class AnimalService : ICRUDService<AnimalListItem, AnimalItem>
    {

        private string baseUrl = "https://localhost:5001/Api/Animals/";
        private readonly HttpClient _httpClient = null;

        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Create(AnimalItem item)
        {
            return _httpClient
                .PostAsJsonAsync<AnimalItem>($"{baseUrl}", item);
        }

        public Task Delete(int id)
        {
            return _httpClient
                .DeleteAsync($"{baseUrl}/{id}");
        }

        public Task<AnimalItem> Get(int id)
        {
            return _httpClient
                .GetFromJsonAsync<AnimalItem>($"{baseUrl}{id}");
        }

        public Task<AnimalListItem[]> GetList()
        {
            return _httpClient
                .GetFromJsonAsync<AnimalListItem[]>($"{baseUrl}");
        }

        public Task<AnimalItem> GetNew()
        {
            return _httpClient
                .GetFromJsonAsync<AnimalItem>($"{baseUrl}new");
        }

        public Task Update(AnimalItem item)
        {
            return _httpClient
                .PutAsJsonAsync($"{baseUrl}/{item.Id}", item);
        }
    }
}
