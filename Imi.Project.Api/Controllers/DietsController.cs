using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Request;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController : ControllerBase
    {
        private readonly IDietService _dietService;

        public DietsController(IDietService dietService)
        {
            _dietService = dietService;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var diets = await _dietService.GetAllAsync();
            
            if (!diets.IsSuccess)
                return BadRequest(diets.ValidationErrors);

            var dietResponseDto = diets.Items.Select(b => new DietResponseDto
            {
                Id = b.Id,
                Name = b.Name
            });

            return Ok(dietResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(int id)
        {
            var diet = await _dietService.GetByIdAsync(id);

            if (!diet.IsSuccess)
                return BadRequest(diet.ValidationErrors);

            DietResponseDto dietResponseDto = new DietResponseDto
            {
                Name = diet.Items.First().Name
            };
            return Ok(dietResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "CanCreate")]
        public async Task<IActionResult> Add([FromForm]DietRequestDto dietRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            
            var result = await _dietService.Add(
                dietRequestDto.Name
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Diet is added!");
        }

        [HttpPut]
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Update([FromForm]DietRequestDto dietRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _dietService.UpdateAsync(
                dietRequestDto.Id,
                dietRequestDto.Name
            );
            
            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Diet is updated!");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanDelete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _dietService.DeleteAsync(id))
            {
                return Ok("Breeding deleted!");
            }
            return BadRequest("Something went wrong! please try again!");
        }

        
    }
}