using HotelGrandioso.Models;
using HotelGrandioso.Services;

namespace HotelGrandioso.UI;

public class ConsoleMenu
{
    private readonly IHotelRepository _repository;

    public ConsoleMenu(IHotelRepository repository)
    {
        _repository = repository;
    }

    public void Run()
    {
        var running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== Hotel Grandioso ===");
            Console.WriteLine("1. Boka rum");
            Console.WriteLine("2. Avboka");
            Console.WriteLine("3. Visa bokningar");
            Console.WriteLine("4. Visa alla rum");
            Console.WriteLine("5. Avsluta");
            Console.Write("Välj: ");

            var val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    BookRoom();
                    break;
                case "2":
                    CancelBooking();
                    break;
                case "3":
                    ShowBookings();
                    break;
                case "4":
                    ShowRooms();
                    break;
                case "5":
                    Console.WriteLine("Avsluta program");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val välj 1-5");
                    break;
            }
        }
    }

    private void ShowRooms()
    {
        foreach (var room in _repository.GetAllRooms())
            Console.WriteLine(
                $" {room.RoomNumber} - {room.RoomType.Name} {room.SizeM2}m² {room.PricePerNight:N0} kr/natt");
    }

    private void ShowBookings()
    {
        var bookings = _repository.GetAllBookings();
        if (bookings.Count == 0)
        {
            Console.WriteLine("inga bokningar");
            return;
        }

        foreach (var b in bookings)
            Console.WriteLine($" #{b.Id} {b.Guest.Name}, rum {b.Room.RoomNumber}, " +
                              $"{b.CheckIn:yyyy-MM-dd} till {b.CheckOut:yyyy-MM-dd}, {b.TotalPrice():N0} kr");
    }

    private void CancelBooking()
    {
        ShowBookings();
        Console.Write("Bokningsnummer att avboka: ");

        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Skriv ett nummer.");
            return;
        }

        var cancelled = _repository.CancelBooking(id);
        Console.WriteLine(cancelled ? "Bokningen är avbokad." : "Hittade ingen bokning med det numret.");
    }

    private void BookRoom()
    {
        Console.Write("Gästnamn: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("E-post: ");
        var email = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("namn måste fyllas i");
            return;
        }

        Console.Write("Incheckning (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var checkIn))
        {
            Console.WriteLine("Ogiltigt datum.");
            return;
        }

        Console.Write("Utcheckning (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var checkOut))
        {
            Console.WriteLine("Ogiltigt datum.");
            return;
        }

        if (checkOut <= checkIn)
        {
            Console.WriteLine("Utcheckning måste vara efter incheckning");
            return;
        }

        Console.WriteLine("Välj rum:");
        ShowRooms();
        Console.Write("Rumsnummer: ");
        if (!int.TryParse(Console.ReadLine(), out var roomNumber))
        {
            Console.WriteLine("Skriv ett rumsnummer");
            return;
        }

        var room = _repository.GetAllRooms().FirstOrDefault(r => r.RoomNumber == roomNumber);
        if (room == null)
        {
            Console.WriteLine("Det rummet finns inte");
            return;
        }

        var guest = new Guest { Name = name, Email = email };
        var booking = _repository.AddBooking(guest, room, checkIn, checkOut);

        var nights = (checkOut - checkIn).Days;
        Console.WriteLine(
            $"Bokning bekräftad! Totalt: {booking.TotalPrice():N0} kr ({nights} nätter x {room.PricePerNight:N0} kr)");
    }
}