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
    public class InterviewersController : ControllerBase
    {
        private readonly EntityRepository _context;

        public InterviewersController(EntityRepository context)
        {
            _context = context;
        }

        // GET: api/Interviewers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interviewer>>> GetInterviewers()
        {
            return await _context.Interviewers.ToListAsync();
        }

        // GET: api/Interviewers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interviewer>> GetInterviewer(int id)
        {
            var interviewer = await _context.Interviewers.FindAsync(id);

            if (interviewer == null)
            {
                return NotFound();
            }

            return interviewer;
        }

        // PUT: api/Interviewers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewer(int id, Interviewer interviewer)
        {
            if (id != interviewer.Id)
            {
                return BadRequest();
            }

            _context.Entry(interviewer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewerExists(id))
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

        // POST: api/Interviewers
        [HttpPost]
        public async Task<ActionResult<Interviewer>> PostInterviewer(Interviewer interviewer)
        {
            _context.Interviewers.Add(interviewer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewer", new { id = interviewer.Id }, interviewer);
        }

        // DELETE: api/Interviewers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interviewer>> DeleteInterviewer(int id)
        {
            var interviewer = await _context.Interviewers.FindAsync(id);
            if (interviewer == null)
            {
                return NotFound();
            }

            _context.Interviewers.Remove(interviewer);
            await _context.SaveChangesAsync();

            return interviewer;
        }

        private bool InterviewerExists(int id)
        {
            return _context.Interviewers.Any(e => e.Id == id);
        }
    }
}
