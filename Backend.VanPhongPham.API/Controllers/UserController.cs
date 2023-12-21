using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.VanPhongPham.API.ModelsSQL;
using Backend.VanPhongPham.API.DTO;

namespace Backend.VanPhongPham.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly VanPhongPhamDbContext _context;

        public UserController(VanPhongPhamDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tuser>>> GetTusers()
        {
          if (_context.Tusers == null)
          {
              return NotFound();
          }
            return await _context.Tusers.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tuser>> GetTuser(Guid id)
        {
          if (_context.Tusers == null)
          {
              return NotFound();
          }
            var tuser = await _context.Tusers.FindAsync(id);

            if (tuser == null)
            {
                return NotFound();
            }

            return tuser;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuser(Guid id, Tuser tuser)
        {
            if (id != tuser.Iduser)
            {
                return BadRequest();
            }

            _context.Entry(tuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuserExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Tuser>> PostTuser(Tuser tuser)
        {
          if (_context.Tusers == null)
          {
              return Problem("Entity set 'VanPhongPhamDbContext.Tusers'  is null.");
          }
            _context.Tusers.Add(tuser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TuserExists(tuser.Iduser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTuser", new { id = tuser.Iduser }, tuser);
        }

        [HttpPost]
        public async Task<ActionResult<Tuser>> LoginAPI(LoginDTO model)
        {
            if (_context.Tusers == null)
            {
                return Problem("Entity set 'VanPhongPhamDbContext.Tusers'  is null.");
            }
            if(string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Email))
            {
                return Problem("Email or Password  is null.");
            }
            var user = await _context.Tusers.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
            if(user == null)
            {
                return BadRequest("Tài khoản hoặc mật khẩu không đúng!");
            }
            else
            {
                return user;
            }
        }


        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuser(Guid id)
        {
            if (_context.Tusers == null)
            {
                return NotFound();
            }
            var tuser = await _context.Tusers.FindAsync(id);
            if (tuser == null)
            {
                return NotFound();
            }

            _context.Tusers.Remove(tuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TuserExists(Guid id)
        {
            return (_context.Tusers?.Any(e => e.Iduser == id)).GetValueOrDefault();
        }
    }
}
