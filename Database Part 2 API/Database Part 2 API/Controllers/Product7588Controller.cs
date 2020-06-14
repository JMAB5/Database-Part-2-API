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
    public class Product2177Controller : ControllerBase
    {
        private readonly _102117588Context _context;

        public Product2177Controller(_102117588Context context)
        {
            _context = context;
        }

        // GET: api/Product7588
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product7588>>> GetProduct7588()
        {
            return await _context.Product7588.ToListAsync();
        }

        // GET: api/Product7588/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product2177>> GetProduct2177(int id)
        {
            // var product7588 = await _context.Product7588.FindAsync(id);

            var product = await Task.FromResult(_context.Product7588.FromSqlRaw("EXEC GET_PRODUCT_BY_ID " +
                "@PPRODID = " + id).ToList());

            if (product == null)
            {
                return NotFound();
            }

            return product[0];
        }

        // PUT: api/Product7588/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct7588(int id, Product7588 product7588)
        {
            if (id != product7588.Productid)
            {
                return BadRequest();
            }

            _context.Entry(product7588).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product7588Exists(id))
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

        // POST: api/Product7588
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product7588>> PostProduct7588(Product7588 p)
        {
            // _context.Product7588.Add(product7588);

            _context.Database.ExecuteSqlRaw("EXEC ADD_PRODUCT @PPRODNAME = " + p.Prodname +
                ", @PBUYPRICE = " + p.Buyprice +
                ", @PSELLPRICE = " + p.Sellprice);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct7588", new { id = p.Prodname }, p);
        }

        // DELETE: api/Product7588/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product7588>> DeleteProduct7588(int id)
        {
            var product7588= await _context.Product7588.FindAsync(id);
            if (product7588 == null)
            {
                return NotFound();
            }

            _context.Product7588.Remove(product7588);
            await _context.SaveChangesAsync();

            return product7588;
        }

        private bool Product7588Exists(int id)
        {
            return _context.Product7588.Any(e => e.Productid == id);
        }
    }
}