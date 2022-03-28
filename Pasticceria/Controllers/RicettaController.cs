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
    public class RicettaController : ControllerBase
    {
        private readonly PasticceriaContext _context;

        public RicettaController(PasticceriaContext context)
        {
            _context = context;
        }

        // GET: api/Ricetta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ricetta>>> GetRicette()
        {
            return await _context.Ricette.ToListAsync();
        }

        // GET: api/Ricetta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ricetta>> GetRicetta(int id)
        {
            var ricetta = await _context.Ricette.FindAsync(id);

            if (ricetta == null)
            {
                return NotFound();
            }

            return ricetta;
        }

        // PUT: api/Ricetta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRicetta(int id, Ricetta ricetta)
        {
            if (id != ricetta.RicettaId)
            {
                return BadRequest();
            }

            _context.Entry(ricetta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RicettaExists(id))
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

        // POST: api/Ricetta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ricetta>> PostRicetta(Ricetta ricetta)
        {
            _context.Ricette.Add(ricetta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRicetta", new { id = ricetta.RicettaId }, ricetta);
        }

        // DELETE: api/Ricetta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRicetta(int id)
        {
            var ricetta = await _context.Ricette.FindAsync(id);
            if (ricetta == null)
            {
                return NotFound();
            }

            _context.Ricette.Remove(ricetta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RicettaExists(int id)
        {
            return _context.Ricette.Any(e => e.RicettaId == id);
        }
    }
}
