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
    public class SellDetailsController : ControllerBase
    {
        private readonly StoreContext _context;

        public SellDetailsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/SellDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellDetail>>> GetSellDetails()
        {
            return await _context.SellDetails.ToListAsync();
        }

        // GET: api/SellDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellDetail>> GetSellDetail(long id)
        {
            var sellDetail = await _context.SellDetails.FindAsync(id);

            if (sellDetail == null)
            {
                return NotFound();
            }

            return sellDetail;
        }

        // PUT: api/SellDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellDetail(long id, SellDetail sellDetail)
        {
            if (id != sellDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(sellDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellDetailExists(id))
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

        // POST: api/SellDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SellDetail>> PostSellDetail(SellDetail sellDetail)
        {
            _context.SellDetails.Add(sellDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSellDetail", new { id = sellDetail.Id }, sellDetail);
        }

        // DELETE: api/SellDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SellDetail>> DeleteSellDetail(long id)
        {
            var sellDetail = await _context.SellDetails.FindAsync(id);
            if (sellDetail == null)
            {
                return NotFound();
            }

            _context.SellDetails.Remove(sellDetail);
            await _context.SaveChangesAsync();

            return sellDetail;
        }

        private bool SellDetailExists(long id)
        {
            return _context.SellDetails.Any(e => e.Id == id);
        }
    }
}
