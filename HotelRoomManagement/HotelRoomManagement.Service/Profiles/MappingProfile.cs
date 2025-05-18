using AutoMapper;
using HotelRoomManagement.Data.Entities;
using HotelRoomManagement.Service.DTOs;

namespace HotelRoomManagement.Service.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Guest, GuestDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<CreateGuestDto, Guest>();
            CreateMap<UpdateGuestDto, Guest>();
            CreateMap<CreateRoomDto, Room>();
            CreateMap<UpdateRoomDto, Room>();
        }
    }
} 