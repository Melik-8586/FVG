using Api_fvg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_fvg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccsController : ControllerBase
    {
        private readonly AccsContext _context;

        public AccsController(AccsContext context)
        {
            _context = context;
        }

        // GET: api/Accs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acc>>> GetAccs()
        {
            return await _context.Accs.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acc>> GetUser(int id)
        {
            var acc = await _context.Accs.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            return acc;
        }

        // GET: api/Users/GetByAcccode/100
        [HttpGet("[action]/{acc_code}")]
        public async Task<ActionResult<Acc>> GetByAcccode(string acc_code)
        {
            var acc = await _context.Accs.FirstOrDefaultAsync(x => x.Acc_code == acc_code);
            if (acc == null)
            {
                return NotFound();
            }
            return acc;
        }

        // PUT: api/Accs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<Acc>> PutAcc(Acc Acc)
        {
            if (Acc == null)
            {
                return BadRequest();
            }
            if (!_context.Accs.Any(x => x.Id == Acc.Id ))
            {
                return NotFound();
            }

            _context.Update(Acc);
            await _context.SaveChangesAsync();
            return Ok(Acc);
        }

        // PUT api/users/login
        [HttpPut("[action]/{acc_code}")]
        public async Task<ActionResult<Acc>> PutByAcccode(string acc_code, Acc acc)
        {
            var acc1 = await _context.Accs.FirstOrDefaultAsync(x => x.Acc_code == acc_code);
            if (acc1 == null)
            {
                return NotFound();
            }
            acc1.Name = acc.Name;
            acc1.Parent  = acc.Parent;

            _context.Entry(acc1).State = EntityState.Modified;
            _context.Update(acc1);
            await _context.SaveChangesAsync();
            return Ok(acc1);
        }

        // POST: api/Accs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acc>> PostAcc(Acc Acc)
        {
            _context.Accs.Add(Acc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcc", new { id = Acc.Id }, Acc);
        }

        // DELETE: api/Accs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcc(int id)
        {
            var Acc = await _context.Accs.FindAsync(id);
            if (Acc == null)
            {
                return NotFound();
            }
            _context.Accs.Remove(Acc);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Users/Tom
        [HttpDelete("[action]/{acc_code}")]
        public async Task<ActionResult<User>> DeleteByAcccode(string acc_code)
        {
            var acc = await _context.Accs.FirstOrDefaultAsync(x => x.Acc_code == acc_code);
            if (acc == null)
            {
                return NotFound();
            }
            _context.Accs.Remove(acc);
            await _context.SaveChangesAsync();
            return Ok(acc);
        }

    }
}
