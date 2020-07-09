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
    public class OccurrencesController : ControllerBase
    {
        private readonly CentralDbContext _context;

        public OccurrencesController(CentralDbContext context)
        {
            _context = context;
        }

        // GET: api/Occurrences
        [HttpGet]
        public ActionResult<IEnumerable<Occurrence>> GetOccurrences()
        {
            return _context.Occurrences.ToList();
        }

        // GET: api/Occurrences/5
        [HttpGet("{id}")]
        public ActionResult<Occurrence> GetOccurrence(int id)
        {
            var occurrence = _context.Occurrences.Single(o => o.OccurrenceId == id);

            if (occurrence == null)
            {
                return NotFound();
            }

            return occurrence;
        }

        // PUT: api/Occurrences/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccurrence(int id, Occurrence occurrence)
        {
            if (id != occurrence.OccurrenceId)
            {
                return BadRequest();
            }

            _context.Entry(occurrence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccurrenceExists(id))
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

        // POST: api/Occurrences
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Occurrence> PostOccurrence(Occurrence occurrence)
        {
            _context.Occurrences.Add(occurrence);
            _context.SaveChanges();

            return CreatedAtAction("GetOccurrence", new { id = occurrence.OccurrenceId }, occurrence);
        }

        // DELETE: api/Occurrences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Occurrence>> DeleteOccurrence(int id)
        {
            var occurrence = await _context.Occurrences.FindAsync(id);
            if (occurrence == null)
            {
                return NotFound();
            }

            _context.Occurrences.Remove(occurrence);
            await _context.SaveChangesAsync();

            return occurrence;
        }

        private bool OccurrenceExists(int id)
        {
            return _context.Occurrences.Any(e => e.OccurrenceId == id);
        }
    }
}
