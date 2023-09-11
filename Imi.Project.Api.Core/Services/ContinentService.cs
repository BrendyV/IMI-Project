using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ContinentService : IContinentService
    {
        private readonly IContinentRepository _continentRepository;
        private readonly IImageService _imageService;

        public ContinentService(IContinentRepository continentRepository, IImageService imageService)
        {
            _continentRepository = continentRepository;
            _imageService = imageService;
        }

        public async Task<ItemResultModel<Continent>> Add(string name, IFormFile image)
        {
            var newContinent = new Continent
            {
                Name = name,
                Image = await _imageService.AddOrUpdateImageAsync<Continent>(image),
            };

            if (!await _continentRepository.AddAsync(newContinent))
            {
                return new ItemResultModel<Continent>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }

            return new ItemResultModel<Continent> { IsSuccess = true };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var continentToDelete = await _continentRepository.GetByIdAsync(id);
            if (continentToDelete == null)
                return false;

            await _continentRepository.DeleteAsync(continentToDelete);
            return true;
        }

        public async Task<ItemResultModel<Continent>> GetAllAsync()
        {
            var continents = await _continentRepository.GetAllAsync();
            ItemResultModel<Continent> itemResultModel = new ItemResultModel<Continent>();
            if (continents != null)
            {
                itemResultModel.Items = continents;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult>
            {
                new ValidationResult("No continents found!")
            };
            return itemResultModel;
        }


        public async Task<ItemResultModel<Continent>> GetByIdAsync(int id)
        {
            ItemResultModel<Continent> itemResultModel = new ItemResultModel<Continent>();
            var continent = await _continentRepository.GetByIdAsync(id);
            if (continent == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No continent found!")
                };
                return itemResultModel;
            }

            itemResultModel.Items = new List<Continent> { continent };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Continent>> UpdateAsync(int id, string name)
        {
            var continent = await _continentRepository.GetByIdAsync(id);
            if (continent == null)
            {
                return new ItemResultModel<Continent>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("Continent not found")
                    }
                };
            }

            continent.Name = name;
            
            if (!await _continentRepository.UpdateAsync(continent))
            {
                return new ItemResultModel<Continent>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                        { new ValidationResult("Something went wrong!")}
                };
            }

            return new ItemResultModel<Continent> { IsSuccess = true };
        }
    }
}