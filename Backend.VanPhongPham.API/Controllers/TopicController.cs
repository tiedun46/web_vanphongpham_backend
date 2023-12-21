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
    public class TopicController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public TopicController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/Topic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ttopic>>> GetTtopics()
        {
          if (_context.Ttopics == null)
          {
              return NotFound();
          }
            return await _context.Ttopics.ToListAsync();
        }

        // GET: api/Topic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ttopic>> GetTtopic(Guid id)
        {
          if (_context.Ttopics == null)
          {
              return NotFound();
          }
            var ttopic = await _context.Ttopics.FindAsync(id);

            if (ttopic == null)
            {
                return NotFound();
            }

            return ttopic;
        }

        // PUT: api/Topic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTtopic(Guid id, Ttopic ttopic)
        {
            if (id != ttopic.Idtopic)
            {
                return BadRequest();
            }

            _context.Entry(ttopic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TtopicExists(id))
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

        // POST: api/Topic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ttopic>> PostTtopic(Ttopic ttopic)
        {
          if (_context.Ttopics == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.Ttopics'  is null.");
          }
            _context.Ttopics.Add(ttopic);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TtopicExists(ttopic.Idtopic))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTtopic", new { id = ttopic.Idtopic }, ttopic);
        }

        // DELETE: api/Topic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTtopic(Guid id)
        {
            if (_context.Ttopics == null)
            {
                return NotFound();
            }
            var ttopic = await _context.Ttopics.FindAsync(id);
            if (ttopic == null)
            {
                return NotFound();
            }

            _context.Ttopics.Remove(ttopic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TtopicExists(Guid id)
        {
            return (_context.Ttopics?.Any(e => e.Idtopic == id)).GetValueOrDefault();
        }
    }
}
