using HotelRoomManagement.Data.Entities;
using HotelRoomManagement.Data.Interfaces;

namespace HotelRoomManagement.Data.Repositories
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public GuestRepository(HotelRoomManagementDataContext context) : base(context)
        {
        }

    }
} 