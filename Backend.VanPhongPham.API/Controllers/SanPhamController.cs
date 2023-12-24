using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.VanPhongPham.API.ModelsSQL;

namespace Backend.VanPhongPham.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public SanPhamController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/SanPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TsanPham>>> GetTsanPhams()
        {
          if (_context.TsanPhams == null)
          {
              return NotFound();
          }
            return await _context.TsanPhams.ToListAsync();
        }

        // GET: api/SanPham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TsanPham>> GetTsanPham(Guid id)
        {
          if (_context.TsanPhams == null)
          {
              return NotFound();
          }
            var tsanPham = await _context.TsanPhams.FindAsync(id);

            if (tsanPham == null)
            {
                return NotFound();
            }

            return tsanPham;
        }

        // PUT: api/SanPham/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTsanPham(Guid id, TsanPham tsanPham)
        {
            if (id != tsanPham.IdsanPham)
            {
                return BadRequest();
            }

            _context.Entry(tsanPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TsanPhamExists(id))
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

        // POST: api/SanPham
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TsanPham>> PostTsanPham(TsanPham tsanPham)
        {
          if (_context.TsanPhams == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.TsanPhams'  is null.");
          }
            tsanPham.IdsanPham = Guid.NewGuid();
            _context.TsanPhams.Add(tsanPham);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TsanPhamExists(tsanPham.IdsanPham))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTsanPham", new { id = tsanPham.IdsanPham }, tsanPham);
        }

        // DELETE: api/SanPham/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTsanPham(Guid id)
        {
            if (_context.TsanPhams == null)
            {
                return NotFound();
            }
            var tsanPham = await _context.TsanPhams.FindAsync(id);
            if (tsanPham == null)
            {
                return NotFound();
            }

            _context.TsanPhams.Remove(tsanPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TsanPhamExists(Guid id)
        {
            return (_context.TsanPhams?.Any(e => e.IdsanPham == id)).GetValueOrDefault();
        }
    }
}
