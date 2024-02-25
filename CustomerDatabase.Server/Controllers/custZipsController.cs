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
    public class custZipsController : ControllerBase
    {
        private readonly CustDataContext _context;

        public custZipsController(CustDataContext context)
        {
            _context = context;
        }

        // GET: api/custZips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<custZip>>> GetcustZip()
        {
            return await _context.custZip.ToListAsync();
        }

        // GET: api/custZips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<custZip>> GetcustZip(int id)
        {
            var custZip = await _context.custZip.FindAsync(id);

            if (custZip == null)
            {
                return NotFound();
            }

            return custZip;
        }

        // PUT: api/custZips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcustZip(int id, custZip custZip)
        {
            if (id != custZip.CustZipID)
            {
                return BadRequest();
            }

            _context.Entry(custZip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!custZipExists(id))
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

        // POST: api/custZips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<custZip>> PostcustZip(custZip custZip)
        {
            _context.custZip.Add(custZip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetcustZip", new { id = custZip.CustZipID }, custZip);
        }

        // DELETE: api/custZips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletecustZip(int id)
        {
            var custZip = await _context.custZip.FindAsync(id);
            if (custZip == null)
            {
                return NotFound();
            }

            _context.custZip.Remove(custZip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool custZipExists(int id)
        {
            return _context.custZip.Any(e => e.CustZipID == id);
        }
    }
}
