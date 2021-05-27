using DotaGrid.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaGrid.Model;
using Microsoft.EntityFrameworkCore;

namespace DotaGrid.API.Controllers
{
    /// <summary>
    /// Denne klassen forteller APIet hvordan den skal håndtere mainattributes. Denne klassen blir ikke så mye brukt siden jeg ikke endte med å la brukeren hjøre handlinger med mainattribute 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MainAttributesController : ControllerBase
    {
        private readonly HeroContext _context;

        public MainAttributesController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/MainAttributes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mainattribute>>> GetMainAttributes()
        {
            return await _context.MainAttributes.ToListAsync();
        }

        // GET: api/MainAttributes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mainattribute>> GetMainAttribute(int id)
        {
            var mainattribute = await _context.MainAttributes.FindAsync(id);

            if (mainattribute == null)
            {
                return NotFound();
            }

            return mainattribute;
        }

        // PUT: api/MainAttributes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainAttribute(int id, Mainattribute mainAttribute)
        {
            if (id != mainAttribute.MainattributeId)
            {
                return BadRequest();
            }

            _context.Entry(mainAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainAttributeExists(id))
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

        // POST: api/MainAttributes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mainattribute>> PostMainAttribute(Mainattribute mainattribute)
        {
            _context.MainAttributes.Add(mainattribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMainAttribute", new { id = mainattribute.MainattributeId }, mainattribute);
        }

        // DELETE: api/MainAttributes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mainattribute>> DeleteMainAttribute(int id)
        {
            var mainattribute = await _context.MainAttributes.FindAsync(id);
            if (mainattribute == null)
            {
                return NotFound();
            }

            _context.MainAttributes.Remove(mainattribute);
            await _context.SaveChangesAsync();

            return mainattribute;
        }

        private bool MainAttributeExists(int id)
        {
            return _context.MainAttributes.Any(e => e.MainattributeId == id);
        }
    }
}
