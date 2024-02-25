using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerDatabase.Server.Data;
using CustomerDatabase.Server.Models;

namespace CustomerDatabase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallHistoriesController : ControllerBase
    {
        private readonly CustDataContext _context;

        public CallHistoriesController(CustDataContext context)
        {
            _context = context;
        }

        // GET: api/CallHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CallHistory>>> GetCallHistory()
        {
            return await _context.CallHistory.ToListAsync();
        }

        // GET: api/CallHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CallHistory>> GetCallHistory(int id)
        {
            var callHistory = await _context.CallHistory.FindAsync(id);

            if (callHistory == null)
            {
                return NotFound();
            }

            return callHistory;
        }

        // PUT: api/CallHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCallHistory(int id, CallHistory callHistory)
        {
            if (id != callHistory.HistoryID)
            {
                return BadRequest();
            }

            _context.Entry(callHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CallHistoryExists(id))
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

        // POST: api/CallHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CallHistory>> PostCallHistory(CallHistory callHistory)
        {
            _context.CallHistory.Add(callHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCallHistory", new { id = callHistory.HistoryID }, callHistory);
        }

        // DELETE: api/CallHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCallHistory(int id)
        {
            var callHistory = await _context.CallHistory.FindAsync(id);
            if (callHistory == null)
            {
                return NotFound();
            }

            _context.CallHistory.Remove(callHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CallHistoryExists(int id)
        {
            return _context.CallHistory.Any(e => e.HistoryID == id);
        }
    }
}
