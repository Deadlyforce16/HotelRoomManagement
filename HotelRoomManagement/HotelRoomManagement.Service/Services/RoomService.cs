using AutoMapper;
using HotelRoomManagement.Data.Entities;
using HotelRoomManagement.Data.Interfaces;
using HotelRoomManagement.Service.DTOs;
using HotelRoomManagement.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomManagement.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDto> CreateRoomAsync(CreateRoomDto roomDto)
        {
            var roomEntity = _mapper.Map<Room>(roomDto);
            await _roomRepository.AddAsync(roomEntity);
            return _mapper.Map<RoomDto>(roomEntity);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _roomRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task UpdateRoomAsync(UpdateRoomDto roomDto)
        {
            var roomEntity = _mapper.Map<Room>(roomDto);
            await _roomRepository.UpdateAsync(roomEntity);
        }
    }
} 