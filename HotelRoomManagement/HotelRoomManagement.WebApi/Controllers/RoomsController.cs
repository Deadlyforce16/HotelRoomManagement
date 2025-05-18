using HotelRoomManagement.Service.DTOs;
using HotelRoomManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> CreateRoom(CreateRoomDto roomDto)
        {
            var createdRoom = await _roomService.CreateRoomAsync(roomDto);
            return CreatedAtAction(nameof(GetRoom), new { id = createdRoom.Id }, createdRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, UpdateRoomDto roomDto)
        {
            if (id != roomDto.Id)
            {
                return BadRequest();
            }

            await _roomService.UpdateRoomAsync(roomDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            await _roomService.DeleteRoomAsync(id);

            return NoContent();
        }
    }
} 