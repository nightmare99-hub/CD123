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
    public class NewsController : ControllerBase
    {
        private readonly APIDBContext _context;

        public NewsController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public IEnumerable<New> GetNews()
        {
            return _context.News;
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNew([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @new = await _context.News.FindAsync(id);

            if (@new == null)
            {
                return NotFound();
            }

            return Ok(@new);
        }

        // PUT: api/News/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNew([FromRoute] int id, [FromBody] New @new)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @new.NewsID)
            {
                return BadRequest();
            }

            _context.Entry(@new).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewExists(id))
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

        // POST: api/News
        [HttpPost]
        public async Task<IActionResult> PostNew([FromBody] New @new)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.News.Add(@new);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNew", new { id = @new.NewsID }, @new);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNew([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @new = await _context.News.FindAsync(id);
            if (@new == null)
            {
                return NotFound();
            }

            _context.News.Remove(@new);
            await _context.SaveChangesAsync();

            return Ok(@new);
        }

        private bool NewExists(int id)
        {
            return _context.News.Any(e => e.NewsID == id);
        }
    }
}