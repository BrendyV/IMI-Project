using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Infrastructure
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAllAnimals();
        Animal GetAnimalById(Guid id);
        Task<Animal> UpdateAnimal(Animal animal);
        Task<Animal> AddAnimal(Animal animal);
        Task<Animal> DeleteAnimal(Guid animalId);

    }
}
