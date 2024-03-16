using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

            var guest = await _guestRepository.GetSingleGuest(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
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

            await _guestRepository.UpdateGuest(guest);

            return NoContent(); 
        }

        // POST: api/Guests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest(Guest guest)

        {
            await _guestRepository.CreateGuest(guest);

            return CreatedAtAction("GetBook", new { id = guest.GuestId }, guest);
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestRepository.DeleteGuest(id);

            return NoContent();
        }
    }
}
