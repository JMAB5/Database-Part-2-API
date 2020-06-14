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
    public class Clientaccount2177Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Clientaccount2177Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Clientaccount7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientaccount7588>>> GetClientaccount7588()
        {
            return await _context.Clientaccount7588.ToListAsync();
        }

        // GET: api/Clientaccount7588/5
        [HttpGet("{id}")]
        public async Task<List<Clientauthorisedaccounts7588>> GetClientaccount7588(int id)
        {
            // var clientaccount7588 = await _context.Clientaccount7588.FindAsync(id);

            // var account = await Task.FromResult(_context.Clientaccount2177.Include(x => x.Authorisedperson2177).ToList());

            var account = await Task.FromResult(_context.Clientauthorisedaccounts7588.FromSqlRaw("EXEC GET_CLIENT_ACCOUNT_BY_ID @PACCOUNTID = " + id).ToList());

            /*
            if (account == null)
            {   
                return NotFound();
            }
            */

            return account;
        }

        // PUT: api/Clientaccount7588/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientaccount7588(int id, Clientaccount7588 clientaccount7588)
        {
            if (id != clientaccount7588.Accountid)
            {
                return BadRequest();
            }

            _context.Entry(clientaccount7588).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Clientaccount2177Exists(id))
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

        // POST: api/Clientaccount7588
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clientaccount7588>> PostClientaccount7588(Clientaccount7588 c)
        {
            // _context.Clientaccount7588.Add(clientaccount7588);


            var accountID = await Task.FromResult(_context.Clientaccount7588.FromSqlRaw("EXEC ADD_CLIENT_ACCOUNT @PACCTNAME = " + c.Acctname +
                ", @PBALANCE = " + c.Balance +
                ", @PCREDITLIMIT = " + c.Creditlimit).ToList());

            // await _context.SaveChangesAsync();
            return accountID[0];
        }

        // DELETE: api/Clientaccount7588/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientaccount7588>> DeleteClientaccount7588(int id)
        {
            var clientaccount7588 = await _context.Clientaccount7588.FindAsync(id);
            if (clientaccount7588 == null)
            {
                return NotFound();
            }

            _context.Clientaccount7588.Remove(clientaccount7588);
            await _context.SaveChangesAsync();

            return clientaccount7588;
        }

        private bool Clientaccount7588Exists(int id)
        {
            return _context.Clientaccount7588.Any(e => e.Accountid == id);
        }
    }
}