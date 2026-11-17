using HotelGrandioso.Data;
using HotelGrandioso.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGrandioso.Services;

public class HotelRepository : IHotelRepository
{
    private readonly HotelContext _context;

    public HotelRepository(HotelContext context)
    {
        _context = context;
    }

    public List<Room> GetAllRooms()
    {
        return _context.Rooms
            .Include(r => r.RoomType)
            .OrderBy(r => r.RoomNumber)
            .ToList();
    }

    public List<Booking> GetAllBookings()
    {
        return _context.Bookings
            .Include(b => b.Room)
            .Include(b => b.Guest)
            .OrderBy(b => b.CheckIn)
            .ToList();
    }
}