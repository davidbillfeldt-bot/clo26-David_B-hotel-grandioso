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
    
    public Booking AddBooking(Guest guest, Room room, DateTime checkIn, DateTime checkOut)
    {
        var booking = new Booking
        {
            Guest = guest,
            Room = room,
            CheckIn = checkIn,
            CheckOut = checkOut
        };
        
            _context.Bookings.Add(booking);
            _context.SaveChanges();

        return booking;
    }

    public bool CancelBooking(int bookingId)
    {
        Booking? booking = _context.Bookings.Find(bookingId);
        if (booking == null) return false;
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return true;
    }
}