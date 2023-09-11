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
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;

        public DietService(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }


        public async Task<ItemResultModel<Diet>> GetAllAsync()
        {
            var diets = await _dietRepository.GetAllAsync();
            ItemResultModel<Diet> itemResultModel = new ItemResultModel<Diet>();
            if (diets != null)
            {
                itemResultModel.Items = diets;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult>
            {
                new ValidationResult("No diets found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Diet>> GetByIdAsync(int id)
        {
            ItemResultModel<Diet> itemResultModel = new ItemResultModel<Diet>();
            var diet = await _dietRepository.GetByIdAsync(id);
            if (diet == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No breeding found!")
                };
                return itemResultModel;
            }

            itemResultModel.Items = new List<Diet> { diet };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dietToDelete = await _dietRepository.GetByIdAsync(id);
            if (dietToDelete == null)
                return false;

            await _dietRepository.DeleteAsync(dietToDelete);
            return true;
        }

        public async Task<ItemResultModel<Diet>> Add(string name)
        {
            var newDiet = new Diet
            {
                Name = name
            };

            if (!await _dietRepository.AddAsync(newDiet))
            {
                return new ItemResultModel<Diet>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }

            return new ItemResultModel<Diet> { IsSuccess = true };
        }

        public async Task<ItemResultModel<Diet>> UpdateAsync(int id, string name)
        {
            var diet = await _dietRepository.GetByIdAsync(id);
            if (diet == null)
            {
                return new ItemResultModel<Diet>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("Diet not found")
                    }
                };
            }
            
            diet.Name = name;
            
            if (!await _dietRepository.UpdateAsync(diet))
            {
                return new ItemResultModel<Diet>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                        { new ValidationResult("Something went wrong!")}
                };
            }

            return new ItemResultModel<Diet> { IsSuccess = true };
        }
    }
}
