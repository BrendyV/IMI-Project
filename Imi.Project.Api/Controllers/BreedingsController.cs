using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Request;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedingsController : ControllerBase
    {
        private readonly IBreedingService _breedingService;

        public BreedingsController(IBreedingService breedingService)
        {
            _breedingService = breedingService;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var breedings = await _breedingService.GetAllAsync();
            
            if (!breedings.IsSuccess)
                return BadRequest(breedings.ValidationErrors);

            var breedingResponseDto = breedings.Items.Select(b => new BreedingResponseDto
            {
                Id = b.Id,
                Name = b.Name
            });

            return Ok(breedingResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(int id)
        {
            var breeding = await _breedingService.GetByIdAsync(id);

            if (!breeding.IsSuccess)
                return BadRequest(breeding.ValidationErrors);

            BreedingResponseDto breedingResponseDto = new BreedingResponseDto
            {
                Name = breeding.Items.First().Name
            };
            return Ok(breedingResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "CanCreate")]
        public async Task<IActionResult> Add([FromForm]BreedingRequestDto breedingRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            
            var result = await _breedingService.Add(
               breedingRequestDto.Name
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Breeding added!");
        }

        [HttpPut]
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Update([FromForm]BreedingRequestDto breedingRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _breedingService.UpdateAsync(
                breedingRequestDto.Id,
                breedingRequestDto.Name
            );
            
            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Breeding is updated!");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanDelete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _breedingService.DeleteAsync(id))
            {
                return Ok("Breeding deleted!");
            }
            return BadRequest("Something went wrong! please try again!");
        }


    }
}