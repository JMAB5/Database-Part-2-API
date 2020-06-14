using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_Part_2_API.Models;
using System.Data.SqlClient;

namespace Database_Part_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Location2177Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Location7588Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Location7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location7588>>> GetLocation7588()
        {
            return await _context.Location7588.ToListAsync();
        }

        // GET: api/Location7588/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location7588>> GetLocation7588(string id)
        {
            var location = await Task.FromResult(_context.Location7588.FromSqlRaw("EXEC GET_LOCATION_BY_ID " +
                "@PLOCID = " + id).ToList());


            if (location == null)
            {
                return NotFound();
            }

            // return Task.FromResult<Location2177>(new List<Location7588>() { location });
            return location[0];
        }

        // PUT: api/Location7588/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation7588(string id, Location7588 l)
        {
            if (id != l.Locationid)
            {
                return BadRequest();
            }

            // _context.Entry(location7588).State = EntityState.Modified;

            try
            {



                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Location7588Exists(id))
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

        // POST: api/Location7588
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Location7588>> PostLocation2177(Location7588 l)
        {
            // _context.Location7588.Add(location7588);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC ADD_LOCATION @PLOCID = " + l.Locationid +
                    ", @PLOCNAME = " + l.Locname +
                    ", @PLOCADDRESS = " + l.Address +
                    ", @PMANAGER = " + l.Manager);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Location7588Exists(l.Locationid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocation7588", new { id = l.Locationid }, l);
        }

        // DELETE: api/Location7588/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Location7588>> DeleteLocation7588(string id)
        {
            var location7588 = await _context.Location7588.FindAsync(id);
            if (location7588 == null)
            {
                return NotFound();
            }

            _context.Location7588.Remove(location7588);
            await _context.SaveChangesAsync();

            return location7588;
        }

        private bool Location7588Exists(string id)
        {
            return _context.Location7588.Any(e => e.Locationid == id);
        }
    }
}