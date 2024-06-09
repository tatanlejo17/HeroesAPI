using HeroesAPI.Models;
using HeroesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroeController : ControllerBase
    {
        private readonly IHeroeRepository _heroeRepository;

        public HeroeController(IHeroeRepository heroeRepository)
        {
            _heroeRepository = heroeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroe>>> GetHeroes()
        {
            var heroes = await _heroeRepository.GetAllAsync();

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Heroe>> GetId(int id)
        {
            var heroes = await _heroeRepository.GetByIdAsync(id);

            if (heroes == null)
            {
                return NotFound();
            }

            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<Heroe>> Post([FromBody] HeroeDto heroeDto)
        {
            var heroe = new Heroe
            {
                HeroeName = heroeDto.HeroeName,
                Skills = heroeDto.Skills
            };

            await _heroeRepository.AddAsync(heroe);

            return CreatedAtAction(nameof(GetId), new { id = heroe.HeroeId }, heroe);
        }

        [HttpPut]
        public async Task<ActionResult<Heroe>> Put(int id, [FromBody] HeroeDto heroeDto)
        {
            var existingHeroe = await _heroeRepository.GetByIdAsync(id);

            if (existingHeroe == null)
            {
                return NotFound();
            }

            existingHeroe.HeroeName = heroeDto.HeroeName;
            existingHeroe.Skills = heroeDto.Skills;

            await _heroeRepository.UpdateAsync(existingHeroe);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingHeroe = _heroeRepository.GetByIdAsync(id);

            if (existingHeroe == null)
            {
                return NotFound();
            }

            await _heroeRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}