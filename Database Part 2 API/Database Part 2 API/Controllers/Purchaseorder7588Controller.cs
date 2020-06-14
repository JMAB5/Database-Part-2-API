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
    public class Purchaseorder7588Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Purchaseorder7588Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Purchaseorder7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchaseorder7558>>> GetPurchaseorder7558()
        {
            return await _context.Purchaseorder7558.ToListAsync();
        }

        // GET: api/Purchaseorder7558/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchaseorder7558>> GetPurchaseorder7558(int id)
        {
            var purchaseorder7558 = await _context.Purchaseorder7558.FindAsync(id);

            if (purchaseorder7558 == null)
            {
                return NotFound();
            }

            return purchaseorder7558;
        }

        // PUT: api/Purchaseorder7558/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseorder7558(int id, Purchaseorder7558 purchaseorder7558)
        {
            if (id != purchaseorder7558.Productid)
            {
                return BadRequest();
            }

            _context.Entry(purchaseorder7558).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Purchaseorder7558Exists(id))
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

        // POST: api/Purchaseorder7558
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Purchaseorder7558>> PostPurchaseorder7558(Purchaseorder7558 p)
        {
            // _context.Purchaseorder7558.Add(purchaseorder2177);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC PURCHASE_STOCK " +
                    "@PPRODID = " + p.Productid +
                    ", @PLOCID = " + p.Locationid +
                    ", @PQTY = " + p.Quantity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Purchaseorder7558Exists(p.Productid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseorder7558", new { id = p.Productid }, p);
        }

        // DELETE: api/Purchaseorder7558/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Purchaseorder7558>> DeletePurchaseorder7558(int id)
        {
            var purchaseorder7558 = await _context.Purchaseorder7558.FindAsync(id);
            if (purchaseorder7558 == null)
            {
                return NotFound();
            }

            _context.Purchaseorder7558.Remove(purchaseorder7558);
            await _context.SaveChangesAsync();

            return purchaseorder7558;
        }

        private bool Purchaseorder7558Exists(int id)
        {
            return _context.Purchaseorder7558.Any(e => e.Productid == id);
        }
    }
}