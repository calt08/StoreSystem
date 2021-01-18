using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly StoreContext _context;

        public SellsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/Sells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sell>>> GetSells()
        {
            return await _context.Sells.ToListAsync();
        }

        // GET: api/Sells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sell>> GetSell(long id)
        {
            var sell = await _context.Sells.FindAsync(id);

            if (sell == null)
            {
                return NotFound();
            }

            return sell;
        }

        // PUT: api/Sells/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSell(long id, Sell sell)
        {
            if (id != sell.Id)
            {
                return BadRequest();
            }

            _context.Entry(sell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellExists(id))
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

        // POST: api/Sells
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sell>> PostSell(Sell sell)
        {
            _context.Sells.Add(sell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSell", new { id = sell.Id }, sell);
        }

        // DELETE: api/Sells/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sell>> DeleteSell(long id)
        {
            var sell = await _context.Sells.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }

            _context.Sells.Remove(sell);
            await _context.SaveChangesAsync();

            return sell;
        }

        private bool SellExists(long id)
        {
            return _context.Sells.Any(e => e.Id == id);
        }
    }
}
