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
    public class BlogController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public BlogController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblog>>> GetTblogs()
        {
          if (_context.Tblogs == null)
          {
              return NotFound();
          }
            return await _context.Tblogs.ToListAsync();
        }

        // GET: api/Blog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblog>> GetTblog(Guid id)
        {
          if (_context.Tblogs == null)
          {
              return NotFound();
          }
            var tblog = await _context.Tblogs.FindAsync(id);

            if (tblog == null)
            {
                return NotFound();
            }

            return tblog;
        }

        // PUT: api/Blog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblog(Guid id, Tblog tblog)
        {
            if (id != tblog.Idblog)
            {
                return BadRequest();
            }

            _context.Entry(tblog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblogExists(id))
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

        // POST: api/Blog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblog>> PostTblog(Tblog tblog)
        {
          if (_context.Tblogs == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.Tblogs'  is null.");
          }
            _context.Tblogs.Add(tblog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblogExists(tblog.Idblog))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblog", new { id = tblog.Idblog }, tblog);
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblog(Guid id)
        {
            if (_context.Tblogs == null)
            {
                return NotFound();
            }
            var tblog = await _context.Tblogs.FindAsync(id);
            if (tblog == null)
            {
                return NotFound();
            }

            _context.Tblogs.Remove(tblog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblogExists(Guid id)
        {
            return (_context.Tblogs?.Any(e => e.Idblog == id)).GetValueOrDefault();
        }
    }
}
