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
    public class MenuController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public MenuController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tmenu>>> GetTmenus()
        {
          if (_context.Tmenus == null)
          {
              return NotFound();
          }
            return await _context.Tmenus.ToListAsync();
        }

        // GET: api/Menu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tmenu>> GetTmenu(Guid id)
        {
          if (_context.Tmenus == null)
          {
              return NotFound();
          }
            var tmenu = await _context.Tmenus.FindAsync(id);

            if (tmenu == null)
            {
                return NotFound();
            }

            return tmenu;
        }

        // PUT: api/Menu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTmenu(Guid id, Tmenu tmenu)
        {
            if (id != tmenu.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(tmenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmenuExists(id))
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

        // POST: api/Menu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tmenu>> PostTmenu(Tmenu tmenu)
        {
          if (_context.Tmenus == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.Tmenus'  is null.");
          }
            _context.Tmenus.Add(tmenu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TmenuExists(tmenu.MenuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTmenu", new { id = tmenu.MenuId }, tmenu);
        }

        // DELETE: api/Menu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTmenu(Guid id)
        {
            if (_context.Tmenus == null)
            {
                return NotFound();
            }
            var tmenu = await _context.Tmenus.FindAsync(id);
            if (tmenu == null)
            {
                return NotFound();
            }

            _context.Tmenus.Remove(tmenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TmenuExists(Guid id)
        {
            return (_context.Tmenus?.Any(e => e.MenuId == id)).GetValueOrDefault();
        }
    }
}
