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
    public class IngredientiController : ControllerBase
    {
        private readonly PasticceriaContext _context;

        public IngredientiController(PasticceriaContext context)
        {
            _context = context;
        }

        // GET: api/Ingredienti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredienti()
        {
            return await _context.Ingredienti.ToListAsync();
        }

        // GET: api/Ingredienti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            var ingrediente = await _context.Ingredienti.FindAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return ingrediente;
        }

        // PUT: api/Ingredienti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngrediente(int id, Ingrediente ingrediente)
        {
            if (id != ingrediente.IngredienteId)
            {
                return BadRequest();
            }

            _context.Entry(ingrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredienteExists(id))
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

        // POST: api/Ingredienti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingrediente>> PostIngrediente(Ingrediente ingrediente)
        {
            _context.Ingredienti.Add(ingrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngrediente", new { id = ingrediente.IngredienteId }, ingrediente);
        }

        // DELETE: api/Ingredienti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngrediente(int id)
        {
            var ingrediente = await _context.Ingredienti.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.Ingredienti.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredienteExists(int id)
        {
            return _context.Ingredienti.Any(e => e.IngredienteId == id);
        }
    }
}
