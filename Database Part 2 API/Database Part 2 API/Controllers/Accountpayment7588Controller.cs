using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_Part_2_API.Models;

namespace Database_Part_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accountpayment2177Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Accountpayment2177Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Accountpayment7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accountpayment7588>>> GetAccountpayment7588()
        {
            return await _context.Accountpayment7588.ToListAsync();
        }

        // GET: api/Accountpayment2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accountpayment7588>> GetAccountpayment7588(int id)
        {
            var accountpayment7588 = await _context.Accountpayment7588.FindAsync(id);

            if (accountpayment7588 == null)
            {
                return NotFound();
            }

            return accountpayment7588;
        }

        // PUT: api/Accountpayment2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountpayment7588(int id, Accountpayment7588 accountpayment7588)
        {
            if (id != accountpayment7588.Accountid)
            {
                return BadRequest();
            }

            _context.Entry(accountpayment7588).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Accountpayment2177Exists(id))
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

        // POST: api/Accountpayment7588
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Accountpayment7588>> PostAccountpayment2177(Accountpayment7588 ap)
        {
            //          _context.Accountpayment7588.Add(ap);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC MAKE_ACCOUNT_PAYMENT " +
                    "@PACCOUNTID = " + ap.Accountid +
                    ", @PAMOUNT = " + ap.Amount);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Accountpayment7588Exists(ap.Accountid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountpayment7588", new { id = ap.Accountid }, ap);
        }

        // DELETE: api/Accountpayment2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Accountpayment7588>> DeleteAccountpayment7588(int id)
        {
            var accountpayment7588 = await _context.Accountpayment7588.FindAsync(id);
            if (accountpayment7588 == null)
            {
                return NotFound();
            }

            _context.Accountpayment7588.Remove(accountpayment7588);
            await _context.SaveChangesAsync();

            return accountpayment7588;
        }

        private bool Accountpayment7588Exists(int id)
        {
            return _context.Accountpayment7588.Any(e => e.Accountid == id);
        }
    }
}