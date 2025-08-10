using Filmes.Api.Data;
using Filmes.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public FilmesController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetAll()
            => Ok(await _db.Filmes.AsNoTracking().OrderByDescending(m => m.Id).ToListAsync());

        [HttpGet("total-likes")]
        public async Task<ActionResult<int>> GetTotalLikes()
        {
            var totalLikes = await _db.Filmes.SumAsync(f => f.Likes);
            return Ok(totalLikes);
        }

        [HttpGet("total-dislikes")]
        public async Task<ActionResult<int>> GetTotalDislikes()
        {
            var totalDislikes = await _db.Filmes.SumAsync(f => f.Dislikes);
            return Ok(totalDislikes);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Filme>> GetById(int id)
        {
            var Filme = await _db.Filmes.FindAsync(id);
            return Filme is null ? NotFound() : Ok(Filme);
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Create(Filme input)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            _db.Filmes.Add(input);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Filme input)
        {
            if (id != input.Id) return BadRequest("IDs divergentes.");
            if (!await _db.Filmes.AnyAsync(m => m.Id == id)) return NotFound();

            _db.Entry(input).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Filme = await _db.Filmes.FindAsync(id);
            if (Filme is null) return NotFound();
            _db.Filmes.Remove(Filme);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
