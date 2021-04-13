using Api_fvg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_fvg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsContext _context;

        public ClientsController(ClientsContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var Client = await _context.Clients.FindAsync(id);
            if (Client == null)
            {
                return NotFound();
            }
            return Client;
        }

        // GET: api/Clients/GetByLogin/Tom
        [HttpGet("[action]/{tpcl}")]
        public async Task<ActionResult<Client>> GetByTpcl(string tpcl)
        {
            var Client = await _context.Clients.FirstOrDefaultAsync(x => x.Tpcl  == tpcl );
            if (Client == null)
            {
                return NotFound();
            }
            return Client;
        }
    }
}
