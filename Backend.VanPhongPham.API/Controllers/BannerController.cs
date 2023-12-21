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
    public class BannerController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public BannerController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/Banner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbanner>>> GetTbanners()
        {
          if (_context.Tbanners == null)
          {
              return NotFound();
          }
            return await _context.Tbanners.ToListAsync();
        }

        // GET: api/Banner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbanner>> GetTbanner(Guid id)
        {
          if (_context.Tbanners == null)
          {
              return NotFound();
          }
            var tbanner = await _context.Tbanners.FindAsync(id);

            if (tbanner == null)
            {
                return NotFound();
            }

            return tbanner;
        }

        // PUT: api/Banner/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbanner(Guid id, Tbanner tbanner)
        {
            if (id != tbanner.Idbanner)
            {
                return BadRequest();
            }

            _context.Entry(tbanner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbannerExists(id))
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

        // POST: api/Banner
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbanner>> PostTbanner(Tbanner tbanner)
        {
          if (_context.Tbanners == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.Tbanners'  is null.");
          }
            _context.Tbanners.Add(tbanner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbannerExists(tbanner.Idbanner))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbanner", new { id = tbanner.Idbanner }, tbanner);
        }

        // DELETE: api/Banner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbanner(Guid id)
        {
            if (_context.Tbanners == null)
            {
                return NotFound();
            }
            var tbanner = await _context.Tbanners.FindAsync(id);
            if (tbanner == null)
            {
                return NotFound();
            }

            _context.Tbanners.Remove(tbanner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbannerExists(Guid id)
        {
            return (_context.Tbanners?.Any(e => e.Idbanner == id)).GetValueOrDefault();
        }
    }
}
