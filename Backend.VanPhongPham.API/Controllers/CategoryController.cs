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
    public class CategoryController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public CategoryController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tcategory>>> GetTcategories()
        {
          if (_context.Tcategories == null)
          {
              return NotFound();
          }
            return await _context.Tcategories.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tcategory>> GetTcategory(Guid id)
        {
          if (_context.Tcategories == null)
          {
              return NotFound();
          }
            var tcategory = await _context.Tcategories.FindAsync(id);

            if (tcategory == null)
            {
                return NotFound();
            }

            return tcategory;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTcategory(Guid id, Tcategory tcategory)
        {
            if (id != tcategory.Idcategory)
            {
                return BadRequest();
            }

            _context.Entry(tcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TcategoryExists(id))
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

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tcategory>> PostTcategory(Tcategory tcategory)
        {
          if (_context.Tcategories == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.Tcategories'  is null.");
          }
            _context.Tcategories.Add(tcategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TcategoryExists(tcategory.Idcategory))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTcategory", new { id = tcategory.Idcategory }, tcategory);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTcategory(Guid id)
        {
            if (_context.Tcategories == null)
            {
                return NotFound();
            }
            var tcategory = await _context.Tcategories.FindAsync(id);
            if (tcategory == null)
            {
                return NotFound();
            }

            _context.Tcategories.Remove(tcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TcategoryExists(Guid id)
        {
            return (_context.Tcategories?.Any(e => e.Idcategory == id)).GetValueOrDefault();
        }
    }
}
