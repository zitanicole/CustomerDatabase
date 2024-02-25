﻿using System;
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
    public class PhoneNumbersController : ControllerBase
    {
        private readonly CustDataContext _context;

        public PhoneNumbersController(CustDataContext context)
        {
            _context = context;
        }

        // GET: api/PhoneNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumber>>> GetPhoneNumber()
        {
            return await _context.PhoneNumber.ToListAsync();
        }

        // GET: api/PhoneNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumber>> GetPhoneNumber(int id)
        {
            var phoneNumber = await _context.PhoneNumber.FindAsync(id);

            if (phoneNumber == null)
            {
                return NotFound();
            }

            return phoneNumber;
        }

        // PUT: api/PhoneNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneNumber(int id, PhoneNumber phoneNumber)
        {
            if (id != phoneNumber.PhoneID)
            {
                return BadRequest();
            }

            _context.Entry(phoneNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNumberExists(id))
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

        // POST: api/PhoneNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhoneNumber>> PostPhoneNumber(PhoneNumber phoneNumber)
        {
            _context.PhoneNumber.Add(phoneNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneNumber", new { id = phoneNumber.PhoneID }, phoneNumber);
        }

        // DELETE: api/PhoneNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneNumber(int id)
        {
            var phoneNumber = await _context.PhoneNumber.FindAsync(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            _context.PhoneNumber.Remove(phoneNumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhoneNumberExists(int id)
        {
            return _context.PhoneNumber.Any(e => e.PhoneID == id);
        }
    }
}
