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
    public class custPhonesController : ControllerBase
    {
        private readonly CustDataContext _context;

        public custPhonesController(CustDataContext context)
        {
            _context = context;
        }

        // GET: api/custPhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<custPhone>>> GetcustPhone()
        {
            return await _context.custPhone.ToListAsync();
        }

        // GET: api/custPhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<custPhone>> GetcustPhone(int id)
        {
            var custPhone = await _context.custPhone.FindAsync(id);

            if (custPhone == null)
            {
                return NotFound();
            }

            return custPhone;
        }

        // PUT: api/custPhones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcustPhone(int id, custPhone custPhone)
        {
            if (id != custPhone.custPhoneID)
            {
                return BadRequest();
            }

            _context.Entry(custPhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!custPhoneExists(id))
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

        // POST: api/custPhones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<custPhone>> PostcustPhone(custPhone custPhone)
        {
            _context.custPhone.Add(custPhone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetcustPhone", new { id = custPhone.custPhoneID }, custPhone);
        }

        // DELETE: api/custPhones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletecustPhone(int id)
        {
            var custPhone = await _context.custPhone.FindAsync(id);
            if (custPhone == null)
            {
                return NotFound();
            }

            _context.custPhone.Remove(custPhone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool custPhoneExists(int id)
        {
            return _context.custPhone.Any(e => e.custPhoneID == id);
        }
    }
}
