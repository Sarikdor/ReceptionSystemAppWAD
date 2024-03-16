using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptoinSystemAppWAD.Data;
using ReceptoinSystemAppWAD.Model;
using ReceptoinSystemAppWAD.Repositories;

namespace ReceptoinSystemAppWAD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly ReceptionSystemAppDbContext _context;
        private readonly IGuestRepository _guestRepository;
        public GuestsController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        // GET: api/Guests
        [HttpGet]
        public async Task<IEnumerable<Guest>> GetGuests()
        {
            return await _guestRepository.GetAllGuests();
        }

        // GET: api/Guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(int id)
        {
          if (_context.Guests == null)
          {
              return NotFound();
          }
            var guest = await _context.Guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return guest;
        }

        // PUT: api/Guests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(int id, Guest guest)
        {
            if (id != guest.GuestId)
            {
                return BadRequest();
            }

            _context.Entry(guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
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

        // POST: api/Guests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest(Guest guest)
        {
          if (_context.Guests == null)
          {
              return Problem("Entity set 'ReceptionSystemAppDbContext.Guests'  is null.");
          }
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuest", new { id = guest.GuestId }, guest);
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            if (_context.Guests == null)
            {
                return NotFound();
            }
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuestExists(int id)
        {
            return (_context.Guests?.Any(e => e.GuestId == id)).GetValueOrDefault();
        }
    }
}
