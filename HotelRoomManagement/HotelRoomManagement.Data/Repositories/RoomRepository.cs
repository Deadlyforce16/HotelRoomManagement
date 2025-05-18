using HotelRoomManagement.Data.Entities;
using HotelRoomManagement.Data.Interfaces;

namespace HotelRoomManagement.Data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HotelRoomManagementDataContext context) : base(context)
        {
        }

    }
} 