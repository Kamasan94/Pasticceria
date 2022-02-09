#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pasticceria.Models;

namespace Pasticceria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetrinaController : ControllerBase
    {
        private readonly PasticceriaContext _context;

        public VetrinaController(PasticceriaContext context)
        {
            _context = context;
        }

        // GET: api/Vetrina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vetrina>>> GetVetrina()
        {
            return await _context.Vetrina.ToListAsync();
        }

        // GET: api/Vetrina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vetrina>> GetVetrina(int id)
        {
            var vetrina = await _context.Vetrina.FindAsync(id);

            if (vetrina == null)
            {
                return NotFound();
            }

            return vetrina;
        }

        // PUT: api/Vetrina/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVetrina(int id, Vetrina vetrina)
        {
            if (id != vetrina.VetrinaId)
            {
                return BadRequest();
            }

            _context.Entry(vetrina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetrinaExists(id))
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

        // POST: api/Vetrina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vetrina>> PostVetrina(Vetrina vetrina)
        {
            _context.Vetrina.Add(vetrina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVetrina", new { id = vetrina.VetrinaId }, vetrina);
        }

        // DELETE: api/Vetrina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVetrina(int id)
        {
            var vetrina = await _context.Vetrina.FindAsync(id);
            if (vetrina == null)
            {
                return NotFound();
            }

            _context.Vetrina.Remove(vetrina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VetrinaExists(int id)
        {
            return _context.Vetrina.Any(e => e.VetrinaId == id);
        }
    }
}
