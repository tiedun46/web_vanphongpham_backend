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
    public class DonHangController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public DonHangController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/DonHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TdonHang>>> GetTdonHangs()
        {
          if (_context.TdonHangs == null)
          {
              return NotFound();
          }
            return await _context.TdonHangs.ToListAsync();
        }

        // GET: api/DonHang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TdonHang>> GetTdonHang(Guid id)
        {
          if (_context.TdonHangs == null)
          {
              return NotFound();
          }
            var tdonHang = await _context.TdonHangs.FindAsync(id);

            if (tdonHang == null)
            {
                return NotFound();
            }

            return tdonHang;
        }

        // PUT: api/DonHang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTdonHang(Guid id, TdonHang tdonHang)
        {
            if (id != tdonHang.IddonHang)
            {
                return BadRequest();
            }

            _context.Entry(tdonHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdonHangExists(id))
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

        // POST: api/DonHang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TdonHang>> PostTdonHang(TdonHang tdonHang)
        {
          if (_context.TdonHangs == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.TdonHangs'  is null.");
          }
            _context.TdonHangs.Add(tdonHang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TdonHangExists(tdonHang.IddonHang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTdonHang", new { id = tdonHang.IddonHang }, tdonHang);
        }

        // DELETE: api/DonHang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTdonHang(Guid id)
        {
            if (_context.TdonHangs == null)
            {
                return NotFound();
            }
            var tdonHang = await _context.TdonHangs.FindAsync(id);
            if (tdonHang == null)
            {
                return NotFound();
            }

            _context.TdonHangs.Remove(tdonHang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TdonHangExists(Guid id)
        {
            return (_context.TdonHangs?.Any(e => e.IddonHang == id)).GetValueOrDefault();
        }
    }
}
