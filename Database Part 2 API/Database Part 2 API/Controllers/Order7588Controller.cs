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
    public class Order2177Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Order2177Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Order7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order7588>>> GetOrder7588()
        {
            var openOrders = await Task.FromResult(_context.Order7588.FromSqlRaw("EXEC GET_OPEN_ORDERS").ToList());

            return openOrders;
        }

        // GET: api/Order7588/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order7588>> GetOrder7588(int id)
        {
            // var order7588 = await _context.Order7588.FindAsync(id);


            var orderID = await Task.FromResult(_context.Order7588.FromSqlRaw("EXEC GET_ORDER_BY_ID " +
                "@PORDERID = " + id).ToList());

            if (orderID == null)
            {
                return NotFound();
            }

            return orderID[0];
        }

        // PUT: api/Order7588/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder7588(int id, Order7588 o)
        {

            if (id != o.Orderid)
            {
                return BadRequest();
            }

            // _context.Entry(o).State = EntityState.Modified;

            try
            {

                await _context.Database.ExecuteSqlRawAsync("EXEC FULLFILL_ORDER " +
                    "@PORDERID = " + id +
                    ", @PACCOUNTID = " + o.Userid);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order7588Exists(id))
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

        // POST: api/Order7588
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order7588>> PostOrder7588(Order7588 o)
        {
            //  _context.Order7588.Add(o);

            var orderID = await Task.FromResult(_context.Order7588.FromSqlRaw("EXEC CREATE_ORDER " +
               "@PSHIPPINGADDRESS = " + o.Shippingaddress +
               ", @PUSERID = " + o.Userid).ToList());

            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetOrder7588", new { id = o.Orderid }, o);

            return orderID[0];
        }

        // DELETE: api/Order7588/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order7588>> DeleteOrder7588(int id)
        {
            var order7588 = await _context.Order7588.FindAsync(id);
            if (order7588 == null)
            {
                return NotFound();
            }

            _context.Order7588.Remove(order7588);
            await _context.SaveChangesAsync();

            return order7588;
        }

        private bool Order7588Exists(int id)
        {
            return _context.Order7588.Any(e => e.Orderid == id);
        }
    }
}