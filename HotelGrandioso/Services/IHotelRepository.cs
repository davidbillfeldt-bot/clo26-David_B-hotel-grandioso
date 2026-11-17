using HotelGrandioso.Models;

namespace HotelGrandioso.Services;

public interface IHotelRepository
{
    List<Room> GetAllRooms();
    List<Booking> GetAllBookings();
}