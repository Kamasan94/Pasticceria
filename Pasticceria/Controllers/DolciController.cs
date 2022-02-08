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
    public class DolciController : ControllerBase
    {
        private readonly PasticceriaContext _context;

        public DolciController(PasticceriaContext context)
        {
            _context = context;
        }

        // GET: api/Dolci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dolce>>> GetDolci()
        {
            return await _context.Dolci.ToListAsync();
        }

        // GET: api/Dolci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dolce>> GetDolce(int id)
        {
            var dolce = await _context.Dolci.FindAsync(id);

            if (dolce == null)
            {
                return NotFound();
            }

            return dolce;
        }

        // PUT: api/Dolci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDolce(int id, Dolce dolce)
        {
            if (id != dolce.DolceId)
            {
                return BadRequest();
            }

            _context.Entry(dolce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DolceExists(id))
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

        // POST: api/Dolci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dolce>> PostDolce(Dolce dolce)
        {
            _context.Dolci.Add(dolce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDolce", new { id = dolce.DolceId }, dolce);
        }

        // DELETE: api/Dolci/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDolce(int id)
        {
            var dolce = await _context.Dolci.FindAsync(id);
            if (dolce == null)
            {
                return NotFound();
            }

            _context.Dolci.Remove(dolce);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DolceExists(int id)
        {
            return _context.Dolci.Any(e => e.DolceId == id);
        }
    }
}
