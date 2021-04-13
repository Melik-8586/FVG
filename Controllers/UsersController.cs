using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_fvg.Models;
using System.Net.Mime;

namespace Api_fvg.Controllers
{
    //    [Route("api/[controller]")]

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
            //if (!_context.Users.Any())
            //{
            //    _context.Users.Add(new User { Name = "Tom", Login = "Tom", Password = "123456" });
            //    _context.Users.Add(new User { Name = "Alice", Login = "Tom", Password = "123456" });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var  user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // GET: api/Users/GetByLogin/Tom
        [HttpGet("[action]/{login}")]
        public async Task<ActionResult<User>> GetByLogin(string login)
        {
            var user = await  _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!_context.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            _context.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/users/login
        [HttpPut("[action]/{login}")]
        public async Task<ActionResult<User>> PutByLogin(string login, User user)
        {
            var user1 = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (user1 == null)
            {
                return NotFound();
            }
            user1.Name = user.Name;
            user1.Password = user.Password;

            _context.Entry(user1).State = EntityState.Modified;
            _context.Update(user1);
            await _context.SaveChangesAsync();
            return Ok(user1);
        }

        // PUT api/users/
        [HttpPut("[action]/{login}")]
        public async Task<ActionResult<User>> PutAllUserByLogin(string login, User user)
        {
            var commandText = "UPDATE Users SET Name=N'" + user.Name + "',password=N'" + user.Password + "' WHERE Login='" + login + "'";
            _context.Database.ExecuteSqlRaw(commandText);

            var user1 = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (user1 == null)
            {
                return NotFound();
            }
            return Ok(user1);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user =await  _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE: api/Users/Tom
        [HttpDelete("[action]/{login}")]
        public async Task<ActionResult<User>> DeleteByLogin(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

    }
}
