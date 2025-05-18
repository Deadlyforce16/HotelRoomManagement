using HotelRoomManagement.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomManagement.Service.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestDto>> GetAllGuestsAsync();
        Task<GuestDto> GetGuestByIdAsync(int id);
        Task<GuestDto> CreateGuestAsync(CreateGuestDto guestDto);
        Task UpdateGuestAsync(UpdateGuestDto guestDto);
        Task DeleteGuestAsync(int id);
    }
} 