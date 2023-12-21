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
    public class MenuGroupController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public MenuGroupController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TmenuGroup>>> GetTmenuGroups()
        {
          if (_context.TmenuGroups == null)
          {
              return NotFound();
          }
            return await _context.TmenuGroups.ToListAsync();
        }

        // GET: api/MenuGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TmenuGroup>> GetTmenuGroup(Guid id)
        {
          if (_context.TmenuGroups == null)
          {
              return NotFound();
          }
            var tmenuGroup = await _context.TmenuGroups.FindAsync(id);

            if (tmenuGroup == null)
            {
                return NotFound();
            }

            return tmenuGroup;
        }

        // PUT: api/MenuGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTmenuGroup(Guid id, TmenuGroup tmenuGroup)
        {
            if (id != tmenuGroup.MenuGroupId)
            {
                return BadRequest();
            }

            _context.Entry(tmenuGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmenuGroupExists(id))
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

        // POST: api/MenuGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TmenuGroup>> PostTmenuGroup(TmenuGroup tmenuGroup)
        {
          if (_context.TmenuGroups == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.TmenuGroups'  is null.");
          }
            _context.TmenuGroups.Add(tmenuGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TmenuGroupExists(tmenuGroup.MenuGroupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTmenuGroup", new { id = tmenuGroup.MenuGroupId }, tmenuGroup);
        }

        // DELETE: api/MenuGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTmenuGroup(Guid id)
        {
            if (_context.TmenuGroups == null)
            {
                return NotFound();
            }
            var tmenuGroup = await _context.TmenuGroups.FindAsync(id);
            if (tmenuGroup == null)
            {
                return NotFound();
            }

            _context.TmenuGroups.Remove(tmenuGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TmenuGroupExists(Guid id)
        {
            return (_context.TmenuGroups?.Any(e => e.MenuGroupId == id)).GetValueOrDefault();
        }
    }
}
