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
    public class Authorisedperson2177Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Authorisedperson2177Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Authorisedperson7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authorisedperson7588>>> GetAuthorisedperson7588()
        {
            return await _context.Authorisedperson7588.ToListAsync();
        }

        // GET: api/Authorisedperson7588/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authorisedperson7588>> GetAuthorisedperson7588(int id)
        {
            var authorisedperson7588 = await _context.Authorisedperson7588.FindAsync(id);

            if (authorisedperson7588 == null)
            {
                return NotFound();
            }

            return authorisedperson7588;
        }

        // PUT: api/Authorisedperson7588/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorisedperson7588(int id, Authorisedperson7588 authorisedperson7588)
        {
            if (id != authorisedperson7588.Userid)
            {
                return BadRequest();
            }

            _context.Entry(authorisedperson7588).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Authorisedperson7588Exists(id))
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

        // POST: api/Authorisedperson7588
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Authorisedperson7588>> PostAuthorisedperson7588(Authorisedperson7588 ap)
        {
            // _context.Authorisedperson7588.Add(authorisedperson2177);


            var authorisedPersonAccountID = await Task.FromResult(_context.Authorisedperson7588.FromSqlRaw("EXEC ADD_AUTHORISED_PERSON " +
                "@PFIRSTNAME = " + ap.Firstname +
                ", @PSURNAME = " + ap.Surname +
                ", @PEMAIL = " + ap.Email +
                ", @PPASSWORD = " + ap.Password +
                ", @PACCOUNTID = " + ap.Accountid).ToList());

            // await _context.SaveChangesAsync();

            return authorisedPersonAccountID[0];
        }

        // DELETE: api/Authorisedperson2177/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Authorisedperson7588>> DeleteAuthorisedperson7588(int id)
        {
            var authorisedperson7588 = await _context.Authorisedperson7588.FindAsync(id);
            if (authorisedperson7588 == null)
            {
                return NotFound();
            }

            _context.Authorisedperson7588.Remove(authorisedperson7588);
            await _context.SaveChangesAsync();

            return authorisedperson7588;
        }

        private bool Authorisedperson7588Exists(int id)
        {
            return _context.Authorisedperson7588.Any(e => e.Userid == id);
        }
    }
}