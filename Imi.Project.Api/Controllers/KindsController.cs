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
using Microsoft.AspNetCore.Http;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindsController : ControllerBase
    {
        private readonly IKindService _kindService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KindsController(IKindService kindService, IHttpContextAccessor httpContextAccessor)
        {
            _kindService = kindService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var kinds = await _kindService.GetAllAsync();
            if (!kinds.IsSuccess)
                return BadRequest(kinds.ValidationErrors);

            var kindResponseDto = kinds.Items.Select(k => new KindResponseDto
            {
                Id = k.Id,
                Name = k.Name,
                Image = k.ImageUrl
            });

            return Ok(kindResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(int id)
        {
            var kind = await _kindService.GetByIdAsync(id);

            if (!kind.IsSuccess)
                return BadRequest(kind.ValidationErrors);

            KindResponseDto continentResponseDto = new KindResponseDto
            {
                Name = kind.Items.First().Name,
                Image = kind.Items.First().ImageUrl
            };

            return Ok(continentResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "CanCreate")]
        public async Task<IActionResult> Add([FromForm]KindAddRequestDto kindAddRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _kindService.Add(
                kindAddRequestDto.Name,
                kindAddRequestDto.Image
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);

            return Ok("Kind is added!");
        }

        [HttpPut]
        [Authorize(Policy = ("CanEdit"))]
        public async Task<IActionResult> Update([FromForm]KindUpdateRequestDto kindUpdateRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _kindService.UpdateAsync(
                kindUpdateRequestDto.Kind.Id,
                kindUpdateRequestDto.Kind.Name
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Kind is updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = ("CanDelete"))]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _kindService.DeleteAsync(id))
            {
                return Ok("Kind is deleted!");
            }
            return BadRequest("Something went wrong! please try again!");
        }

    }
}
