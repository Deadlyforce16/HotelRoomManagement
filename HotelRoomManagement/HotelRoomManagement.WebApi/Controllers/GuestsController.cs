using HotelRoomManagement.Service.DTOs;
using HotelRoomManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDto>>> GetGuests()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDto>> GetGuest(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        [HttpPost]
        public async Task<ActionResult<GuestDto>> CreateGuest(CreateGuestDto guestDto)
        {
            var createdGuest = await _guestService.CreateGuestAsync(guestDto);
            return CreatedAtAction(nameof(GetGuest), new { id = createdGuest.Id }, createdGuest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, UpdateGuestDto guestDto)
        {
            if (id != guestDto.Id)
            {
                return BadRequest();
            }

            await _guestService.UpdateGuestAsync(guestDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            await _guestService.DeleteGuestAsync(id);

            return NoContent();
        }
    }
} 