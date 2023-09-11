using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> AddOrUpdateImageAsync<T>(IFormFile image, string fileName = "");
        string GetImageUrl<T>(string image);
    }
}
