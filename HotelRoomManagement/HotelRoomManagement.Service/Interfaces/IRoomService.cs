using HotelRoomManagement.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomManagement.Service.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
        Task<RoomDto> GetRoomByIdAsync(int id);
        Task<RoomDto> CreateRoomAsync(CreateRoomDto roomDto);
        Task UpdateRoomAsync(UpdateRoomDto roomDto);
        Task DeleteRoomAsync(int id);
    }
} 