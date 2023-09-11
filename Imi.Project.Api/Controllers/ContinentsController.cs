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
    public class ContinentsController : ControllerBase
    {
        private readonly IContinentService _continentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContinentsController(IContinentService continentService, IHttpContextAccessor httpContextAccessor)
        {
            _continentService = continentService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var continents = await _continentService.GetAllAsync();
            if (!continents.IsSuccess)
                return BadRequest(continents.ValidationErrors);

            var continentResponseDto = continents.Items.Select(c => new ContinentResponseDto()
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.ImageUrl
            });

            return Ok(continentResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(int id)
        {
            var continent = await _continentService.GetByIdAsync(id);

            if (!continent.IsSuccess)
                return BadRequest(continent.ValidationErrors);

            ContinentResponseDto continentResponseDto = new ContinentResponseDto
            {
                Name = continent.Items.First().Name,
                Image = continent.Items.First().ImageUrl
            };

            return Ok(continentResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "CanCreate")]
        public async Task<IActionResult> Add([FromForm] ContinentAddRequest continentAddRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _continentService.Add(
                continentAddRequest.Name,
                continentAddRequest.Image
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);

            return Ok("Continent added!");
        }

        [HttpPut]
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Update([FromForm]ContinentUpdateRequestDto continentUpdateRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _continentService.UpdateAsync(
                continentUpdateRequestDto.Continent.Id,
                continentUpdateRequestDto.Continent.Name
                );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Continent is updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanDelete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _continentService.DeleteAsync(id))
            {
                return Ok("Breeding deleted!");
            }
            return BadRequest("Something went wrong! please try again!");
        }

        
    }
}