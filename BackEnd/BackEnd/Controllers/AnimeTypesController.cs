using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeTypesController : ControllerBase
    {
        private readonly APIDBContext _context;

        public AnimeTypesController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/AnimeTypes
        [HttpGet]
        public IEnumerable<AnimeType> GetAnimeTypes()
        {
            return _context.AnimeTypes;
        }

        // GET: api/AnimeTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimeType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animeType = await _context.AnimeTypes.FindAsync(id);

            if (animeType == null)
            {
                return NotFound();
            }

            return Ok(animeType);
        }

        // PUT: api/AnimeTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeType([FromRoute] int id, [FromBody] AnimeType animeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animeType.AnimeTypeID)
            {
                return BadRequest();
            }

            _context.Entry(animeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AnimeTypes
        [HttpPost]
        public async Task<IActionResult> PostAnimeType([FromBody] AnimeType animeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AnimeTypes.Add(animeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeType", new { id = animeType.AnimeTypeID }, animeType);
        }

        // DELETE: api/AnimeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animeType = await _context.AnimeTypes.FindAsync(id);
            if (animeType == null)
            {
                return NotFound();
            }

            _context.AnimeTypes.Remove(animeType);
            await _context.SaveChangesAsync();

            return Ok(animeType);
        }

        private bool AnimeTypeExists(int id)
        {
            return _context.AnimeTypes.Any(e => e.AnimeTypeID == id);
        }
    }
}