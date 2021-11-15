using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenFinal01.Data;
using ExamenFinal01.Models;

namespace ExamenFinal01.Controllers
{
    [Route("api/Catedraticoes")]
    [ApiController]
    public class CatedraticoesController : ControllerBase
    {
        private readonly ExamenFinal01Context _context;

        public CatedraticoesController(ExamenFinal01Context context)
        {
            _context = context;
        }

        // GET: api/Catedraticoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catedratico>>> GetCatedratico()
        {
            return await _context.Catedratico.ToListAsync();
        }

        // GET: api/Catedraticoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catedratico>> GetCatedratico(int id)
        {
            var catedratico = await _context.Catedratico.FindAsync(id);

            if (catedratico == null)
            {
                return NotFound();
            }

            return catedratico;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatedratico(int id, Catedratico catedratico)
        {
            if (id != catedratico.CodigoCatedratico)
            {
                return BadRequest();
            }

            _context.Entry(catedratico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatedraticoExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Catedratico>> PostCatedratico(Catedratico catedratico)
        {
            _context.Catedratico.Add(catedratico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatedratico", new { id = catedratico.CodigoCatedratico }, catedratico);
        }

        // DELETE: api/Catedraticoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Catedratico>> DeleteCatedratico(int id)
        {
            var catedratico = await _context.Catedratico.FindAsync(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            _context.Catedratico.Remove(catedratico);
            await _context.SaveChangesAsync();

            return catedratico;
        }

        private bool CatedraticoExists(int id)
        {
            return _context.Catedratico.Any(e => e.CodigoCatedratico == id);
        }
    }
}
