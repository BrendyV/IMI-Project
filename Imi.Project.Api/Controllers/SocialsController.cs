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
    public class SocialsController : ControllerBase
    {
        private readonly ISocialService _socialService;

        public SocialsController(ISocialService socialService)
        {
            _socialService = socialService;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var socials = await _socialService.GetAllAsync();
            
            if (!socials.IsSuccess)
                return BadRequest(socials.ValidationErrors);

            var socialResponseDto = socials.Items.Select(b => new SocialResponseDto
            {
                Id = b.Id,
                Name = b.Name
            });

            return Ok(socialResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(int id)
        {
            var social = await _socialService.GetByIdAsync(id);

            if (!social.IsSuccess)
                return BadRequest(social.ValidationErrors);

            SocialResponseDto socialResponseDto = new SocialResponseDto()
            {
                Name = social.Items.First().Name
            };
            return Ok(socialResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "CanCreate")]
        public async Task<IActionResult> Add ([FromForm]SocialRequestDto socialRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            
            var result = await _socialService.Add(
                socialRequestDto.Name
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Social is added!");
        }

        [HttpPut]
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Update ([FromForm]SocialRequestDto socialRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _socialService.UpdateAsync(
                socialRequestDto.Id,
                socialRequestDto.Name
            );
            
            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);
            
            return Ok("Social is updated!");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanDelete")]
        public async Task<IActionResult> Delete (int id)
        {
            if (await _socialService.DeleteAsync(id))
            {
                return Ok("Breeding deleted!");
            }
            return BadRequest("Something went wrong! please try again!");
        }
    }
}
