using Imi.Project.Api.Core.Dtos.Request;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Blazor.Models.Animal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        #region Repositories

        private readonly IAnimalService _animalService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AnimalDbContext _context;

        #endregion

        public AnimalsController(IAnimalService animalService, IHttpContextAccessor httpContextAccessor, AnimalDbContext context)
        {
            _animalService = animalService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }


        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var animals = await _animalService.GetAllAsync();

            if (!animals.IsSuccess)
            {
                return BadRequest(animals.ValidationErrors);
            }

            var animalsResponseDto = animals.Items.Select(a => new  
            {
                Id = a.Id,
                NameDutch = a.NameDutch,
                NameFamily = a.NameFamily,
                Breeding = a.Breeding.Name,
                Diet = a.Diet.Name,
                Continent = a.Continent.Name,
                Kind = a.Kind.Name,
                Social = a.Social.Name,
                TempMin = a.TempMin,
                TempMax = a.TempMax,
                PhMin = a.PhMin,
                PhMax = a.PhMax,
                GhMin = a.GhMin,
                GhMax = a.GhMax,
                Image = a.ImageUrl
            });

            return Ok(animalsResponseDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (!animal.IsSuccess)
            {
                return BadRequest(animal.ValidationErrors);
            }

            AnimalResponseDto animalResponseDto = new AnimalResponseDto
            {
                NameDutch = animal.Items.First().NameDutch,
                NameFamily = animal.Items.First().NameFamily,
                Breeding = animal.Items.First().Breeding.Name,
                Diet = animal.Items.First().Diet.Name,
                Continent = animal.Items.First().Continent.Name,
                Kind = animal.Items.First().Kind.Name,
                Social = animal.Items.First().Social.Name,
                TempMin = animal.Items.First().TempMin,
                TempMax = animal.Items.First().TempMax,
                PhMin = animal.Items.First().PhMin,
                PhMax = animal.Items.First().PhMax,
                GhMin = animal.Items.First().GhMin,
                GhMax = animal.Items.First().GhMax,
                Image = animal.Items.First().ImageUrl
            };

            return Ok(animalResponseDto);
        }

        [HttpPost]
        [Authorize(Policy = "CanCreate")]
        public async Task<IActionResult> Add([FromForm] AnimalAddRequestDto animalAddRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var result = await _animalService.Add(
                animalAddRequestDto.NameDutch,
                animalAddRequestDto.NameFamily,
                animalAddRequestDto.Image,
                animalAddRequestDto.BreedingId,
                animalAddRequestDto.ContinentId,
                animalAddRequestDto.DietId,
                animalAddRequestDto.KindId,
                animalAddRequestDto.SocialId,
                animalAddRequestDto.TempMin,
                animalAddRequestDto.TempMax,
                animalAddRequestDto.PhMin,
                animalAddRequestDto.PhMax,
                animalAddRequestDto.GhMin,
                animalAddRequestDto.GhMax
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);

            return Ok("Animal added!");
        }


        [HttpPut]
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Update([FromForm] AnimalUpdateRequestDto animalUpdateRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var result = await _animalService.UpdateAsync(
                animalUpdateRequestDto.Animal.Id,
                animalUpdateRequestDto.Animal.NameDutch,
                animalUpdateRequestDto.Animal.NameFamily,
                animalUpdateRequestDto.Animal.BreedingId,
                animalUpdateRequestDto.Animal.ContinentId,
                animalUpdateRequestDto.Animal.DietId,
                animalUpdateRequestDto.Animal.KindId,
                animalUpdateRequestDto.Animal.SocialId,
                animalUpdateRequestDto.Animal.TempMin,
                animalUpdateRequestDto.Animal.TempMax,
                animalUpdateRequestDto.Animal.PhMin,
                animalUpdateRequestDto.Animal.PhMax,
                animalUpdateRequestDto.Animal.GhMin,
                animalUpdateRequestDto.Animal.GhMax
            );

            if (!result.IsSuccess)
                return BadRequest(result.ValidationErrors);

            return Ok("Animal updateted");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanDelete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _animalService.DeleteAsync(id))
            {
                return Ok("Animal deleted!");
            }

            return BadRequest("Something went wrong! please try again!");
        }


        [HttpGet("breeding/{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetByBreedingId(int id)
        {
            var animals = await _animalService.GetByBreedingIdAsync(id);

            if (!animals.IsSuccess)
            {
                return BadRequest(animals.ValidationErrors);
            }

            var animalResponseDto = animals.Items.Select(a =>
                new AnimalResponseDto
                {
                    Id = a.Id,
                    NameDutch = a.NameDutch,
                    NameFamily = a.NameFamily,
                    Breeding = a.Breeding.Name,
                    TempMin = a.TempMin,
                    TempMax = a.TempMax,
                    PhMin = a.PhMin,
                    PhMax = a.PhMax,
                    GhMin = a.GhMin,
                    GhMax = a.GhMax,
                    Image = a.ImageUrl,
                });
            return Ok(animalResponseDto);
        }
        
        [HttpGet("continent/{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetByContinentId(int id)
        {
            var animals = await _animalService.GetByContinentIdAsync(id);

            if (!animals.IsSuccess)
            {
                return BadRequest(animals.ValidationErrors);
            }

            var animalResponseDto = animals.Items.Select(a =>
                new AnimalResponseDto
                {
                    Id = a.Id,
                    NameDutch = a.NameDutch,
                    NameFamily = a.NameFamily,
                    Continent = a.Continent.Name,
                    TempMin = a.TempMin,
                    TempMax = a.TempMax,
                    PhMin = a.PhMin,
                    PhMax = a.PhMax,
                    GhMin = a.GhMin,
                    GhMax = a.GhMax,
                    Image = a.ImageUrl,
                });
            return Ok(animalResponseDto);
        }
        
        [HttpGet("diet/{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetByDietId(int id)
        {
            var animals = await _animalService.GetByDietIdAsync(id);

            if (!animals.IsSuccess)
            {
                return BadRequest(animals.ValidationErrors);
            }

            var animalResponseDto = animals.Items.Select(a =>
                new AnimalResponseDto
                {
                    Id = a.Id,
                    NameDutch = a.NameDutch,
                    NameFamily = a.NameFamily,
                    Diet = a.Diet.Name,
                    TempMin = a.TempMin,
                    TempMax = a.TempMax,
                    PhMin = a.PhMin,
                    PhMax = a.PhMax,
                    GhMin = a.GhMin,
                    GhMax = a.GhMax,
                    Image = a.ImageUrl,
                });
            return Ok(animalResponseDto);
        }
        
        [HttpGet("kind/{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetByKindId(int id)
        {
            var animals = await _animalService.GetByKindIdAsync(id);

            if (!animals.IsSuccess)
            {
                return BadRequest(animals.ValidationErrors);
            }

            var animalResponseDto = animals.Items.Select(a =>
                new AnimalResponseDto
                {
                    Id = a.Id,
                    NameDutch = a.NameDutch,
                    NameFamily = a.NameFamily,
                    Kind = a.Kind.Name,
                    TempMin = a.TempMin,
                    TempMax = a.TempMax,
                    PhMin = a.PhMin,
                    PhMax = a.PhMax,
                    GhMin = a.GhMin,
                    GhMax = a.GhMax,
                    Image = a.ImageUrl,
                });
            return Ok(animalResponseDto);
        }
        
        [HttpGet("social/{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetBySocialId(int id)
        {
            var animals = await _animalService.GetBySocialIdAsync(id);

            if (!animals.IsSuccess)
            {
                return BadRequest(animals.ValidationErrors);
            }

            var animalResponseDto = animals.Items.Select(a =>
                new AnimalResponseDto
                {
                    Id = a.Id,
                    NameDutch = a.NameDutch,
                    NameFamily = a.NameFamily,
                    Social = a.Social.Name,
                    TempMin = a.TempMin,
                    TempMax = a.TempMax,
                    PhMin = a.PhMin,
                    PhMax = a.PhMax,
                    GhMin = a.GhMin,
                    GhMax = a.GhMax,
                    Image = a.ImageUrl,
                });
            return Ok(animalResponseDto);
        }
        
        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            var animal = new AnimalItem()
            {
                Breedings = await getBreedings(),
                Continents = await getContinents(),
                Diets = await getDiets(),
                Kinds = await getKinds(),
                Socials = await getSocials()
            };
            if (animal.Breedings.Count() > 0 && animal.Continents.Count() > 0 && animal.Diets.Count() > 0 && animal.Kinds.Count() > 0 && animal.Socials.Count() > 0)
            {
                animal.BreedingId = animal.Breedings.First().Value;
                animal.ContinentId = animal.Continents.First().Value;
                animal.DietId = animal.Diets.First().Value;
                animal.KindId = animal.Kinds.First().Value;
                animal.SocialId = animal.Socials.First().Value;
            }
            return Ok(animal);
        }
        
        private async Task<InputSelectItem[]> getBreedings()
        {
            return await _context.Breedings
                .Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArrayAsync();
        }
        
        private async Task<InputSelectItem[]> getContinents()
        {
            return await _context.Continents
                .Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArrayAsync();
        }
        
        private async Task<InputSelectItem[]> getDiets()
        {
            return await _context.Diets
                .Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArrayAsync();
        }
        
        private async Task<InputSelectItem[]> getKinds()
        {
            return await _context.Kinds
                .Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArrayAsync();
        }
        
        private async Task<InputSelectItem[]> getSocials()
        {
            return await _context.Socials
                .Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArrayAsync();
        }
    }
}