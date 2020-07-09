using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicrosservicesController : ControllerBase
    {
        private readonly CentralDbContext _context;

        public MicrosservicesController(CentralDbContext context)
        {
            _context = context;
        }

        // GET: api/Microsservices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Microsservice>>> GetMicrosservices()
        {
            return await _context.Microsservices.ToListAsync();
        }

        // GET: api/Microsservices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Microsservice>> GetMicrosservice(int id)
        {
            var microsservice = await _context.Microsservices.FindAsync(id);

            if (microsservice == null)
            {
                return NotFound();
            }

            return microsservice;
        }

        // PUT: api/Microsservices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMicrosservice(int id, Microsservice microsservice)
        {
            if (id != microsservice.MicrosserviceId)
            {
                return BadRequest();
            }

            _context.Entry(microsservice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MicrosserviceExists(id))
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

        // POST: api/Microsservices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Microsservice>> PostMicrosservice(Microsservice microsservice)
        {
            _context.Microsservices.Add(microsservice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMicrosservice", new { id = microsservice.MicrosserviceId }, microsservice);
        }

        // DELETE: api/Microsservices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Microsservice>> DeleteMicrosservice(int id)
        {
            var microsservice = await _context.Microsservices.FindAsync(id);
            if (microsservice == null)
            {
                return NotFound();
            }

            _context.Microsservices.Remove(microsservice);
            await _context.SaveChangesAsync();

            return microsservice;
        }

        private bool MicrosserviceExists(int id)
        {
            return _context.Microsservices.Any(e => e.MicrosserviceId == id);
        }
    }
}
