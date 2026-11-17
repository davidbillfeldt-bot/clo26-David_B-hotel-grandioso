using HotelGrandioso.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGrandioso.Data;

public class HotelContext : DbContext
{
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Booking> Bookings => Set<Booking>();
    

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string connectionString = Environment.GetEnvironmentVariable("HOTEL_DB")
                                  ?? "Data Source=hotel.db";
        options.UseSqlite(connectionString);
    }
}