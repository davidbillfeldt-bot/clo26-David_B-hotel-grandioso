using HotelGrandioso.Models;

namespace HotelGrandioso.Services;

public interface IHotelRepository
{
    List<Room> GetAllRooms();
    List<Booking> GetAllBookings();

    Booking AddBooking(Guest guest, Room room, DateTime checkIn, DateTime checkOut);
    bool CancelBooking(int bookingId);
}