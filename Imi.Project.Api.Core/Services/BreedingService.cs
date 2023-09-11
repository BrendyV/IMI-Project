using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services.Models;

namespace Imi.Project.Api.Core.Services
{
    public class BreedingService : IBreedingService
    {
        private readonly IBreedingRepository _breedingRepository;

        public BreedingService(IBreedingRepository breedingRepository)
        {
            _breedingRepository = breedingRepository;
        }


        public async Task<ItemResultModel<Breeding>> GetAllAsync()
        {
            var breedings = await _breedingRepository.GetAllAsync();
            ItemResultModel<Breeding> itemResultModel = new ItemResultModel<Breeding>();
            if (breedings != null)
            {
                itemResultModel.Items = breedings;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult>
            {
                new ValidationResult("No breedings found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Breeding>> GetByIdAsync(int id)
        {
            ItemResultModel<Breeding> itemResultModel = new ItemResultModel<Breeding>();
            var breeding = await _breedingRepository.GetByIdAsync(id);
            if (breeding == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No breeding found!")
                };
                return itemResultModel;
            }

            itemResultModel.Items = new List<Breeding> { breeding };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var breedingToDelete = await _breedingRepository.GetByIdAsync(id);
            if (breedingToDelete == null)
                return false;

            await _breedingRepository.DeleteAsync(breedingToDelete);
            return true;
        }

        public async Task<ItemResultModel<Breeding>> Add(string name)
        {
            var newBreeding = new Breeding
            {
                Name = name
            };

            if (!await _breedingRepository.AddAsync(newBreeding))
            {
                return new ItemResultModel<Breeding>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }

            return new ItemResultModel<Breeding> { IsSuccess = true };
        }

        public async Task<ItemResultModel<Breeding>> UpdateAsync(int id, string name)
        {
            var breeding = await _breedingRepository.GetByIdAsync(id);
            if (breeding == null)
            {
                return new ItemResultModel<Breeding>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("Breeding not found")
                    }
                };
            }
            
            breeding.Name = name;
            
            if (!await _breedingRepository.UpdateAsync(breeding))
            {
                return new ItemResultModel<Breeding>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                        { new ValidationResult("Something went wrong!")}
                };
            }

            return new ItemResultModel<Breeding> { IsSuccess = true };
        }
    }
}