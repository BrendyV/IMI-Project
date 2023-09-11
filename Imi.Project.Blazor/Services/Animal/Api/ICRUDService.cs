using System;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Animal.Api
{
    public interface ICRUDService<T, K>
    {
        Task<T[]> GetList();
        Task<K> GetNew();
        Task<K> Get(int id);
        Task Create(K item);
        Task Update(K item);
        Task Delete(int id);
    }
}
