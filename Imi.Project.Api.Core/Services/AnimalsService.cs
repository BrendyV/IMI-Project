using AutoMapper;
using Imi.Project.Api.Core.Dtos.Request;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class AnimalsService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IImageService _imageService;

        public AnimalsService(IAnimalRepository animalRepository, IImageService imageService, IMapper mapper, IBreedingRepository breedingRepository = null, IContinentRepository continentRepository = null, IDietRepository dietRepository = null, IKindRepository kindRepository = null, ISocialRepository socialRepository = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _animalRepository = animalRepository;
            _imageService = imageService;
        }

        public async Task<ItemResultModel<Animal>> Add(string nameDutch, string nameFamily, IFormFile image, int kindId, int breedingId, int dietId, int continentId, int socialId, int tempMin, int tempMax, int phMin, int phMax, int ghMin, int ghMax)
        {
            var newAnimal = new Animal
            {
                NameDutch = nameDutch,
                NameFamily = nameFamily,
                KindId = kindId,
                BreedingId = breedingId,
                SocialId = socialId,
                DietId = dietId,
                ContinentId = continentId,
                TempMin = tempMin,
                TempMax = tempMax,
                PhMin = phMin,
                PhMax = phMax,
                GhMin = ghMin,
                GhMax = ghMax,
                Image = await _imageService.AddOrUpdateImageAsync<Animal>(image),
            };

            if (!await _animalRepository.AddAsync(newAnimal))
            {
                return new ItemResultModel<Animal>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }

                };
            }

            return new ItemResultModel<Animal> { IsSuccess = true };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var animalToDelete = await _animalRepository.GetByIdAsync(id);
            if (animalToDelete == null)
            {
                return false;
            }
            await _animalRepository.DeleteAsync(animalToDelete);
            return true;
        }

        public async Task<ItemResultModel<Animal>> GetAllAsync()
        {
            var animals = await _animalRepository.GetAllAsync();
            ItemResultModel<Animal> itemResultModel = new ItemResultModel<Animal>();
            if (animals != null)
            {
                itemResultModel.Items = animals;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult>
            {
                new ValidationResult("No animals found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Animal>> GetByIdAsync(int id)
        {
            ItemResultModel<Animal> itemResultModel = new ItemResultModel<Animal>();
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No product found!")
                };
                return itemResultModel;
            }
            itemResultModel.Items = new List<Animal> { animal };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Animal>> UpdateAsync(int id, string nameDutch, string nameFamily, int kindId, int breedingId, 
            int dietId, int continentId, int socialId, int tempMin, int tempMax, int phMin, int phMax, int ghMin, int ghMax)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
            {
                return new ItemResultModel<Animal>
                {
                    IsSuccess = false,
                    ValidationErrors =
                    new List<ValidationResult> {
                    new ValidationResult("Animal not found!")
                    }
                };
            }

            animal.NameDutch = nameDutch;
            animal.NameFamily = nameFamily;
            animal.KindId = kindId;
            animal.BreedingId = breedingId;
            animal.SocialId = socialId;
            animal.DietId = dietId;
            animal.ContinentId = continentId;
            animal.TempMin = tempMin;
            animal.TempMax = tempMax;
            animal.PhMin = phMin;
            animal.PhMax = phMax;
            animal.GhMin = ghMin;
            animal.GhMax = ghMax;
            

            if (!await _animalRepository.UpdateAsync(animal))
            {
                return new ItemResultModel<Animal>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Something went wrong!")}
                };
            }

            return new ItemResultModel<Animal> { IsSuccess = true };
        }

        public async Task<ItemResultModel<Animal>> GetByBreedingIdAsync(int id)
        {
            var animals = await _animalRepository.GetByBreedingIdAsync(id);

            if (animals == null)
            {
                return new ItemResultModel<Animal> 
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("No animals found!") }
                };
            }

            return new ItemResultModel<Animal>
            {
                IsSuccess = true,
                Items = animals
            };
            
            
        }

        public async Task<ItemResultModel<Animal>> GetByContinentIdAsync(int id)
        {
            var animals = await _animalRepository.GetByContinentIdAsync(id);

            if (animals == null)
            {
                return new ItemResultModel<Animal> 
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("No animals found!") }
                };
            }

            return new ItemResultModel<Animal>
            {
                IsSuccess = true,
                Items = animals
            };
        }

        public async Task<ItemResultModel<Animal>> GetByDietIdAsync(int id)
        {
            var animals = await _animalRepository.GetByDietIdAsync(id);

            if (animals == null)
            {
                return new ItemResultModel<Animal> 
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("No animals found!") }
                };
            }

            return new ItemResultModel<Animal>
            {
                IsSuccess = true,
                Items = animals
            };
        }

        public async Task<ItemResultModel<Animal>> GetByKindIdAsync(int id)
        {
            var animals = await _animalRepository.GetByKindIdAsync(id);

            if (animals == null)
            {
                return new ItemResultModel<Animal> 
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("No animals found!") }
                };
            }

            return new ItemResultModel<Animal>
            {
                IsSuccess = true,
                Items = animals
            };
        }

        public async Task<ItemResultModel<Animal>> GetBySocialIdAsync(int id)
        {
            var animals = await _animalRepository.GetBySocialIdAsync(id);

            if (animals == null)
            {
                return new ItemResultModel<Animal> 
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("No animals found!") }
                };
            }

            return new ItemResultModel<Animal>
            {
                IsSuccess = true,
                Items = animals
            };
        }
    }
}
