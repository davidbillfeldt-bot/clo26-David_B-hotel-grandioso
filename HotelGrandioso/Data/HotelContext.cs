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
        var connectionString = Environment.GetEnvironmentVariable("HOTEL_DB")
                               ?? "Data Source=hotel.db";
        options.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomType>().HasData(
            new RoomType { Id = 1, Name = "Standard", Description = "Standardrum" },
            new RoomType { Id = 2, Name = "Luxury", Description = "Lyxsvit" },
            new RoomType { Id = 3, Name = "Bridal", Description = "Bröllopssvit" }
        );

        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, RoomNumber = 101, Floor = 1, SizeM2 = 80, PricePerNight = 800, RoomTypeId = 1 },
            new Room { Id = 2, RoomNumber = 102, Floor = 1, SizeM2 = 80, PricePerNight = 800, RoomTypeId = 1 },
            new Room { Id = 3, RoomNumber = 103, Floor = 1, SizeM2 = 80, PricePerNight = 800, RoomTypeId = 1 },
            new Room { Id = 4, RoomNumber = 104, Floor = 1, SizeM2 = 80, PricePerNight = 800, RoomTypeId = 1 },
            new Room { Id = 5, RoomNumber = 105, Floor = 1, SizeM2 = 80, PricePerNight = 800, RoomTypeId = 1 },
            new Room { Id = 6, RoomNumber = 201, Floor = 2, SizeM2 = 100, PricePerNight = 1000, RoomTypeId = 1 },
            new Room { Id = 7, RoomNumber = 202, Floor = 2, SizeM2 = 100, PricePerNight = 1000, RoomTypeId = 1 },
            new Room { Id = 8, RoomNumber = 203, Floor = 2, SizeM2 = 100, PricePerNight = 1000, RoomTypeId = 1 },
            new Room { Id = 9, RoomNumber = 204, Floor = 2, SizeM2 = 100, PricePerNight = 1000, RoomTypeId = 1 },
            new Room { Id = 10, RoomNumber = 205, Floor = 2, SizeM2 = 100, PricePerNight = 1000, RoomTypeId = 1 },
            new Room { Id = 11, RoomNumber = 301, Floor = 3, SizeM2 = 120, PricePerNight = 1200, RoomTypeId = 1 },
            new Room { Id = 12, RoomNumber = 302, Floor = 3, SizeM2 = 120, PricePerNight = 1200, RoomTypeId = 1 },
            new Room { Id = 13, RoomNumber = 303, Floor = 3, SizeM2 = 120, PricePerNight = 1200, RoomTypeId = 1 },
            new Room { Id = 14, RoomNumber = 304, Floor = 3, SizeM2 = 180, PricePerNight = 2800, RoomTypeId = 2 },
            new Room { Id = 15, RoomNumber = 305, Floor = 3, SizeM2 = 220, PricePerNight = 3500, RoomTypeId = 3 }
        );
    }
}