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
    public class custAddressesController : ControllerBase
    {
        private readonly CustDataContext _context;

        public custAddressesController(CustDataContext context)
        {
            _context = context;
        }

        // GET: api/custAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<custAddress>>> GetcustAddress()
        {
            return await _context.custAddress.ToListAsync();
        }

        // GET: api/custAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<custAddress>> GetcustAddress(int id)
        {
            var custAddress = await _context.custAddress.FindAsync(id);

            if (custAddress == null)
            {
                return NotFound();
            }

            return custAddress;
        }

        // PUT: api/custAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutcustAddress(int id, custAddress custAddress)
        {
            if (id != custAddress.CustAddressID)
            {
                return BadRequest();
            }

            _context.Entry(custAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!custAddressExists(id))
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

        // POST: api/custAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<custAddress>> PostcustAddress(custAddress custAddress)
        {
            _context.custAddress.Add(custAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetcustAddress", new { id = custAddress.CustAddressID }, custAddress);
        }

        // DELETE: api/custAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletecustAddress(int id)
        {
            var custAddress = await _context.custAddress.FindAsync(id);
            if (custAddress == null)
            {
                return NotFound();
            }

            _context.custAddress.Remove(custAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool custAddressExists(int id)
        {
            return _context.custAddress.Any(e => e.CustAddressID == id);
        }
    }
}
