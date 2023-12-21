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
    public class HinhThucThanhToanController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public HinhThucThanhToanController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/HinhThucThanhToan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThinhThucThanhToan>>> GetThinhThucThanhToans()
        {
          if (_context.ThinhThucThanhToans == null)
          {
              return NotFound();
          }
            return await _context.ThinhThucThanhToans.ToListAsync();
        }

        // GET: api/HinhThucThanhToan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThinhThucThanhToan>> GetThinhThucThanhToan(Guid id)
        {
          if (_context.ThinhThucThanhToans == null)
          {
              return NotFound();
          }
            var thinhThucThanhToan = await _context.ThinhThucThanhToans.FindAsync(id);

            if (thinhThucThanhToan == null)
            {
                return NotFound();
            }

            return thinhThucThanhToan;
        }

        // PUT: api/HinhThucThanhToan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThinhThucThanhToan(Guid id, ThinhThucThanhToan thinhThucThanhToan)
        {
            if (id != thinhThucThanhToan.IdhinhThucThanhToan)
            {
                return BadRequest();
            }

            _context.Entry(thinhThucThanhToan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThinhThucThanhToanExists(id))
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

        // POST: api/HinhThucThanhToan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThinhThucThanhToan>> PostThinhThucThanhToan(ThinhThucThanhToan thinhThucThanhToan)
        {
          if (_context.ThinhThucThanhToans == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.ThinhThucThanhToans'  is null.");
          }
            _context.ThinhThucThanhToans.Add(thinhThucThanhToan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThinhThucThanhToanExists(thinhThucThanhToan.IdhinhThucThanhToan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThinhThucThanhToan", new { id = thinhThucThanhToan.IdhinhThucThanhToan }, thinhThucThanhToan);
        }

        // DELETE: api/HinhThucThanhToan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThinhThucThanhToan(Guid id)
        {
            if (_context.ThinhThucThanhToans == null)
            {
                return NotFound();
            }
            var thinhThucThanhToan = await _context.ThinhThucThanhToans.FindAsync(id);
            if (thinhThucThanhToan == null)
            {
                return NotFound();
            }

            _context.ThinhThucThanhToans.Remove(thinhThucThanhToan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThinhThucThanhToanExists(Guid id)
        {
            return (_context.ThinhThucThanhToans?.Any(e => e.IdhinhThucThanhToan == id)).GetValueOrDefault();
        }
    }
}
