using AutoMapper;
using HotelRoomManagement.Data.Entities;
using HotelRoomManagement.Data.Interfaces;
using HotelRoomManagement.Service.DTOs;
using HotelRoomManagement.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomManagement.Service.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;

        public GuestService(IGuestRepository guestRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
        }

        public async Task<GuestDto> CreateGuestAsync(CreateGuestDto guestDto)
        {
            var guestEntity = _mapper.Map<Guest>(guestDto);
            await _guestRepository.AddAsync(guestEntity);
            return _mapper.Map<GuestDto>(guestEntity);
        }

        public async Task DeleteGuestAsync(int id)
        {
            await _guestRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GuestDto>> GetAllGuestsAsync()
        {
            var guests = await _guestRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GuestDto>>(guests);
        }

        public async Task<GuestDto> GetGuestByIdAsync(int id)
        {
            var guest = await _guestRepository.GetByIdAsync(id);
            return _mapper.Map<GuestDto>(guest);
        }

        public async Task UpdateGuestAsync(UpdateGuestDto guestDto)
        {
            var guestEntity = _mapper.Map<Guest>(guestDto);
            await _guestRepository.UpdateAsync(guestEntity);
        }
    }
} 