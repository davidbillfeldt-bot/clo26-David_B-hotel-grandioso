namespace HotelGrandioso.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
    
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    
    public List<Booking> Bookings { get; set; } = new();
    // Priset räknas ut i stället för att sparas, så det alltid stämmer
    // även om rummets pris eller datumen ändras
    public decimal TotalPrice()
    {
        if (Room == null)
        {
            throw new InvalidOperationException("Rummet är inte inläst.");
        }

        int nights = (CheckOut - CheckIn).Days;
        return nights * Room.PricePerNight;
    }
}