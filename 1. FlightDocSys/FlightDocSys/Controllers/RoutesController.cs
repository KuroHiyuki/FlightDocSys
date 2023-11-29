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
    public class RoutesController : ControllerBase
    {
        private readonly FlightDocSysContext _context;

        public RoutesController(FlightDocSysContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Route>>> GetRoutes()
        {
          if (_context.Routes == null)
          {
              return NotFound();
          }
            return await _context.Routes.ToListAsync();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Route>> GetRoute(string id)
        {
          if (_context.Routes == null)
          {
              return NotFound();
          }
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // PUT: api/Routes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(string id, Models.Route route)
        {
            if (id != route.RouteId)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Routes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Route>> PostRoute(Models.Route route)
        {
          if (_context.Routes == null)
          {
              return Problem("Entity set 'FlightDocSysContext.Routes'  is null.");
          }
            _context.Routes.Add(route);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RouteExists(route.RouteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoute", new { id = route.RouteId }, route);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(string id)
        {
            if (_context.Routes == null)
            {
                return NotFound();
            }
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteExists(string id)
        {
            return (_context.Routes?.Any(e => e.RouteId == id)).GetValueOrDefault();
        }
    }
}
