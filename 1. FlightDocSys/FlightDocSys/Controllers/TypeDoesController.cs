using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightDocSys.Models;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDoesController : ControllerBase
    {
        private readonly FlightDocSysContext _context;

        public TypeDoesController(FlightDocSysContext context)
        {
            _context = context;
        }

        // GET: api/TypeDoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDo>>> GetTypeDos()
        {
          if (_context.TypeDos == null)
          {
              return NotFound();
          }
            return await _context.TypeDos.ToListAsync();
        }

        // GET: api/TypeDoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeDo>> GetTypeDo(int id)
        {
          if (_context.TypeDos == null)
          {
              return NotFound();
          }
            var typeDo = await _context.TypeDos.FindAsync(id);

            if (typeDo == null)
            {
                return NotFound();
            }

            return typeDo;
        }

        // PUT: api/TypeDoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeDo(int id, TypeDo typeDo)
        {
            if (id != typeDo.TypeDoId)
            {
                return BadRequest();
            }

            _context.Entry(typeDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDoExists(id))
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

        // POST: api/TypeDoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeDo>> PostTypeDo(TypeDo typeDo)
        {
          if (_context.TypeDos == null)
          {
              return Problem("Entity set 'FlightDocSysContext.TypeDos'  is null.");
          }
            _context.TypeDos.Add(typeDo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TypeDoExists(typeDo.TypeDoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTypeDo", new { id = typeDo.TypeDoId }, typeDo);
        }

        // DELETE: api/TypeDoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeDo(int id)
        {
            if (_context.TypeDos == null)
            {
                return NotFound();
            }
            var typeDo = await _context.TypeDos.FindAsync(id);
            if (typeDo == null)
            {
                return NotFound();
            }

            _context.TypeDos.Remove(typeDo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeDoExists(int id)
        {
            return (_context.TypeDos?.Any(e => e.TypeDoId == id)).GetValueOrDefault();
        }
    }
}
