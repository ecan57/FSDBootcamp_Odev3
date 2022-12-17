using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odev_3API.Models.ViewModels;
using Odev3_API.Models;

namespace Odev_3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrencisController : ControllerBase
    {//4. Controllerlarımıza Automapper uygulanmasını sağlarız.
        private readonly ObsDbContext _context;
        private readonly IMapper _mapper;
        public OgrencisController(ObsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Ogrencis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ogrenci>>> GetOgrenciler()
        {
            var ogrenciler = _context.Ogrenciler.ToListAsync();
            //return await _context.Ogrenciler.ToListAsync();

            //Uygulanacak alanlar için tek tek eklendi.
            return Ok( _mapper.Map<IEnumerable<OgrenciVM>>(await _context.Ogrenciler.ToListAsync()));
        }

        // GET: api/Ogrencis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ogrenci>> GetOgrenci(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OgrenciVM>(ogrenci));
        }

        // PUT: api/Ogrencis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOgrenci(int id, OgrenciVM vm)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (id != ogrenci.OgrenciNo)
            {
                return BadRequest();
            }

            //_context.Entry(ogrenci).State = EntityState.Modified;
            _mapper.Map(vm, ogrenci);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OgrenciExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok(_mapper.Map<OgrenciVM>(ogrenci));
        }

        // POST: api/Ogrencis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ogrenci>> PostOgrenci(OgrenciVM vm)
        {
            var ogrenci = _mapper.Map<Ogrenci>(vm);
            
            _context.Ogrenciler.Add(ogrenci);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOgrenci", new { id = ogrenci.OgrenciNo }, _mapper.Map<OgrenciVM>(vm));
        }

        // DELETE: api/Ogrencis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOgrenci(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OgrenciExists(int id)
        {
            return _context.Ogrenciler.Any(e => e.OgrenciNo == id);
        }
    }
}
