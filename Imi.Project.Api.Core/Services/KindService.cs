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
using Microsoft.AspNetCore.Http;

namespace Imi.Project.Api.Core.Services
{
    public class KindService : IKindService
    {
        private readonly IKindRepository _kindRepository;
        private readonly IImageService _imageService;

        public KindService(IKindRepository kindRepository, IImageService imageService)
        {
            _kindRepository = kindRepository;
            _imageService = imageService;
        }

        public async Task<ItemResultModel<Kind>> Add(string name, IFormFile image)
        {
            var newKind = new Kind
            {
                Name = name,
                Image = await _imageService.AddOrUpdateImageAsync<Kind>(image),
            };

            if (!await _kindRepository.AddAsync(newKind))
            {
                return new ItemResultModel<Kind>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }

            return new ItemResultModel<Kind> { IsSuccess = true };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var kindToDelete = await _kindRepository.GetByIdAsync(id);
            if (kindToDelete == null)
                return false;

            await _kindRepository.DeleteAsync(kindToDelete);
            return true;
        }

        public async Task<ItemResultModel<Kind>> GetAllAsync()
        {
            var kinds = await _kindRepository.GetAllAsync();
            ItemResultModel<Kind> itemResultModel = new ItemResultModel<Kind>();
            if (kinds != null)
            {
                itemResultModel.Items = kinds;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult>
            {
                new ValidationResult("No kinds found!")
            };
            return itemResultModel;
        }


        public async Task<ItemResultModel<Kind>> GetByIdAsync(int id)
        {
            ItemResultModel<Kind> itemResultModel = new ItemResultModel<Kind>();
            var kind = await _kindRepository.GetByIdAsync(id);
            if (kind == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No kind found!")
                };
                return itemResultModel;
            }

            itemResultModel.Items = new List<Kind> { kind };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Kind>> UpdateAsync(int id, string name)
        {
            var kind = await _kindRepository.GetByIdAsync(id);
            if (kind == null)
            {
                return new ItemResultModel<Kind>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("Kind not found")
                    }
                };
            }

            kind.Name = name;

            
            if (!await _kindRepository.UpdateAsync(kind))
            {
                return new ItemResultModel<Kind>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                        { new ValidationResult("Something went wrong!")}
                };
            }

            return new ItemResultModel<Kind> { IsSuccess = true };
        }
    }
}
