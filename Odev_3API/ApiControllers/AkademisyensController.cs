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
    public class AkademisyensController : ControllerBase
    {
        private readonly ObsDbContext _context;

        public AkademisyensController(ObsDbContext context)
        {
            _context = context;
        }

        // GET: api/Akademisyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Akademisyen>>> GetAkademisyenler()
        {
            return await _context.Akademisyenler.ToListAsync();
        }

        // GET: api/Akademisyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Akademisyen>> GetAkademisyen(Guid id)
        {
            var akademisyen = await _context.Akademisyenler.FindAsync(id);

            if (akademisyen == null)
            {
                return NotFound();
            }

            return akademisyen;
        }

        // PUT: api/Akademisyens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAkademisyen(Guid id, Akademisyen akademisyen)
        {
            if (id != akademisyen.AkademisyenId)
            {
                return BadRequest();
            }

            _context.Entry(akademisyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AkademisyenExists(id))
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

        // POST: api/Akademisyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Akademisyen>> PostAkademisyen(Akademisyen akademisyen)
        {
            _context.Akademisyenler.Add(akademisyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAkademisyen", new { id = akademisyen.AkademisyenId }, akademisyen);
        }

        // DELETE: api/Akademisyens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAkademisyen(Guid id)
        {
            var akademisyen = await _context.Akademisyenler.FindAsync(id);
            if (akademisyen == null)
            {
                return NotFound();
            }

            _context.Akademisyenler.Remove(akademisyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AkademisyenExists(Guid id)
        {
            return _context.Akademisyenler.Any(e => e.AkademisyenId == id);
        }
    }
}
