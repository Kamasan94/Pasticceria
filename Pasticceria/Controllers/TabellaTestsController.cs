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
    public class TabellaTestsController : ControllerBase
    {
        private readonly PasticceriaContext _context;

        public TabellaTestsController(PasticceriaContext context)
        {
            _context = context;
        }

        // GET: api/TabellaTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabellaTest>>> GettabellaTest()
        {
            return await _context.tabellaTest.ToListAsync();
        }

        // GET: api/TabellaTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TabellaTest>> GetTabellaTest(int id)
        {
            var tabellaTest = await _context.tabellaTest.FindAsync(id);

            if (tabellaTest == null)
            {
                return NotFound();
            }

            return tabellaTest;
        }

        // PUT: api/TabellaTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTabellaTest(int id, TabellaTest tabellaTest)
        {
            if (id != tabellaTest.TestId)
            {
                return BadRequest();
            }

            _context.Entry(tabellaTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabellaTestExists(id))
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

        // POST: api/TabellaTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TabellaTest>> PostTabellaTest(TabellaTest tabellaTest)
        {
            _context.tabellaTest.Add(tabellaTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTabellaTest", new { id = tabellaTest.TestId }, tabellaTest);
        }

        // DELETE: api/TabellaTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTabellaTest(int id)
        {
            var tabellaTest = await _context.tabellaTest.FindAsync(id);
            if (tabellaTest == null)
            {
                return NotFound();
            }

            _context.tabellaTest.Remove(tabellaTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TabellaTestExists(int id)
        {
            return _context.tabellaTest.Any(e => e.TestId == id);
        }
    }
}
