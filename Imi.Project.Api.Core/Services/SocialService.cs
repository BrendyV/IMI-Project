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
    public class SocialService : ISocialService
    {
        private readonly ISocialRepository _socialRepository;

        public SocialService(ISocialRepository socialRepository)
        {
            _socialRepository = socialRepository;
        }
        
        public async Task<ItemResultModel<Social>> GetAllAsync()
        {
            var socials = await _socialRepository.GetAllAsync();
            ItemResultModel<Social> itemResultModel = new ItemResultModel<Social>();
            if (socials != null)
            {
                itemResultModel.Items = socials;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }

            itemResultModel.ValidationErrors = new List<ValidationResult>
            {
                new ValidationResult("No socials found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Social>> GetByIdAsync(int id)
        {
            ItemResultModel<Social> itemResultModel = new ItemResultModel<Social>();
            var social = await _socialRepository.GetByIdAsync(id);
            if (social == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No social found!")
                };
                return itemResultModel;
            }

            itemResultModel.Items = new List<Social> { social };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var socialToDelete = await _socialRepository.GetByIdAsync(id);
            if (socialToDelete == null)
                return false;

            await _socialRepository.DeleteAsync(socialToDelete);
            return true;
        }

        public async Task<ItemResultModel<Social>> Add(string name)
        {
            var newSocial = new Social
            {
                Name = name
            };

            if (!await _socialRepository.AddAsync(newSocial))
            {
                return new ItemResultModel<Social>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }

            return new ItemResultModel<Social> { IsSuccess = true };
        }

        public async Task<ItemResultModel<Social>> UpdateAsync(int id, string name)
        {
            var breeding = await _socialRepository.GetByIdAsync(id);
            if (breeding == null)
            {
                return new ItemResultModel<Social>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("Social not found")
                    }
                };
            }
            
            breeding.Name = name;
            
            if (!await _socialRepository.UpdateAsync(breeding))
            {
                return new ItemResultModel<Social>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                        { new ValidationResult("Something went wrong!")}
                };
            }

            return new ItemResultModel<Social> { IsSuccess = true };
        }
    }
}
