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
    public class Orderline7588Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Orderline7588Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Orderline7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderline7588>>> GetOrderline7588()
        {
            return await _context.Orderline7588.ToListAsync();
        }

        // GET: api/Orderline2177/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderline7588>> GetOrderline7588(int id)
        {
            var orderline7588 = await _context.Orderline7588.FindAsync(id);

            if (orderline7588 == null)
            {
                return NotFound();
            }

            return orderline7588;
        }

        // PUT: api/Orderline2177/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderline7588(int id, Orderline7588 orderline7588)
        {
            if (id != orderline7588.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(orderline7588).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Orderline7588Exists(id))
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

        // POST: api/Orderline7588
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orderline7588>> PostOrderline7588(Orderline7588 ol)
        {
            // _context.Orderline7588.Add(ol);
            try
            {

                await _context.Database.ExecuteSqlRawAsync("EXEC ADD_PRODUCT_TO_ORDER @PORDERID = " + ol.Orderid +
                    ", @PPRODIID = " + ol.Productid +
                    ", @PQTY = " + ol.Quantity +
                    ", @DISCOUNT = " + ol.Discount);
            }
            catch (DbUpdateException)
            {
                if (Orderline2177Exists(ol.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderline7588", new { id = ol.Orderid }, ol);
        }

        // DELETE: api/Orderline7588/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteOrderline7588(Orderline7588 ol)
        {
            // var orderline7588 = await _context.Orderline7588.FindAsync(id);

            var order = await _context.Database.ExecuteSqlRawAsync("EXEC REMOVE_PRODUCT_FROM_ORDER " +
                "@PORDERID = " + ol.Orderid + ", @PPRODIID = " + ol.Productid);
            /*
            if (order == null)
            {
                return NotFound();
            }*/
            if (order == 0)
            {
                return -1;
            }


            // _context.Orderline2177.Remove(orderline7588);
            // await _context.SaveChangesAsync();

            return 1;
        }

        private bool Orderline7588Exists(int id)
        {
            return _context.Orderline7588.Any(e => e.Orderid == id);
        }
    }
}