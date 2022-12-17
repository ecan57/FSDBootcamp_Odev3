using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odev3_API.Models;

namespace Odev_3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersController : ControllerBase
    {
        private readonly ObsDbContext _context;

        public DersController(ObsDbContext context)
        {
            _context = context;
        }

        // GET: api/Ders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ders>>> GetDersler()
        {
            return await _context.Dersler.ToListAsync();
        }

        // GET: api/Ders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ders>> GetDers(Guid id)
        {
            var ders = await _context.Dersler.FindAsync(id);

            if (ders == null)
            {
                return NotFound();
            }

            return ders;
        }

        // PUT: api/Ders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDers(Guid id, Ders ders)
        {
            if (id != ders.DersId)
            {
                return BadRequest();
            }

            _context.Entry(ders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DersExists(id))
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

        // POST: api/Ders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ders>> PostDers(Ders ders)
        {
            _context.Dersler.Add(ders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDers", new { id = ders.DersId }, ders);
        }

        // DELETE: api/Ders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDers(Guid id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }

            _context.Dersler.Remove(ders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DersExists(Guid id)
        {
            return _context.Dersler.Any(e => e.DersId == id);
        }
    }
}
