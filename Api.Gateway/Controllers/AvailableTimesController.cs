using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Concrete;
using Repository.EntityFramework;

namespace Api.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableTimesController : ControllerBase
    {
        private readonly EntityRepository _context;

        public AvailableTimesController(EntityRepository context)
        {
            _context = context;
        }

        // GET: api/AvailableTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableTime>>> GetAvailableTimes()
        {
            return await _context.AvailableTimes.ToListAsync();
        }

        // GET: api/AvailableTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvailableTime>> GetAvailableTime(int id)
        {
            var availableTime = await _context.AvailableTimes.FindAsync(id);

            if (availableTime == null)
            {
                return NotFound();
            }

            return availableTime;
        }

        // PUT: api/AvailableTimes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailableTime(int id, AvailableTime availableTime)
        {
            if (id != availableTime.Id)
            {
                return BadRequest();
            }

            _context.Entry(availableTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableTimeExists(id))
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

        // POST: api/AvailableTimes
        [HttpPost]
        public async Task<ActionResult<AvailableTime>> PostAvailableTime(AvailableTime availableTime)
        {
            _context.AvailableTimes.Add(availableTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailableTime", new { id = availableTime.Id }, availableTime);
        }

        // DELETE: api/AvailableTimes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AvailableTime>> DeleteAvailableTime(int id)
        {
            var availableTime = await _context.AvailableTimes.FindAsync(id);
            if (availableTime == null)
            {
                return NotFound();
            }

            _context.AvailableTimes.Remove(availableTime);
            await _context.SaveChangesAsync();

            return availableTime;
        }

        private bool AvailableTimeExists(int id)
        {
            return _context.AvailableTimes.Any(e => e.Id == id);
        }
    }
}
