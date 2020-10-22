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
    public class ViewersController : ControllerBase
    {
        private readonly APIDBContext _context;

        public ViewersController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/Viewers
        [HttpGet]
        public IEnumerable<Viewer> GetViewers()
        {
            return _context.Viewers;
        }

        // GET: api/Viewers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetViewer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viewer = await _context.Viewers.FindAsync(id);

            if (viewer == null)
            {
                return NotFound();
            }

            return Ok(viewer);
        }

        // PUT: api/Viewers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViewer([FromRoute] int id, [FromBody] Viewer viewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewer.ViewerID)
            {
                return BadRequest();
            }

            _context.Entry(viewer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewerExists(id))
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

        // POST: api/Viewers
        [HttpPost]
        public async Task<IActionResult> PostViewer([FromBody] Viewer viewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Viewers.Add(viewer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViewer", new { id = viewer.ViewerID }, viewer);
        }

        // DELETE: api/Viewers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViewer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viewer = await _context.Viewers.FindAsync(id);
            if (viewer == null)
            {
                return NotFound();
            }

            _context.Viewers.Remove(viewer);
            await _context.SaveChangesAsync();

            return Ok(viewer);
        }

        private bool ViewerExists(int id)
        {
            return _context.Viewers.Any(e => e.ViewerID == id);
        }
    }
}