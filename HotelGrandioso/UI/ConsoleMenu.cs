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
        bool running = true;

        while (running)
        {
            Console.WriteLine("=== Hotel Grandioso ===");
            Console.WriteLine("1. Boka rum");
            Console.WriteLine("2. Avboka");
            Console.WriteLine("3. Visa bokningar");
            Console.WriteLine("4. Visa alla rum");
            Console.WriteLine("5. Avsluta");
            Console.Write("Välj: ");

            string? val = Console.ReadLine();

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
        {
            Console.WriteLine($" {room.RoomNumber} - {room.RoomType.Name} {room.SizeM2}m² {room.PricePerNight:N0} kr/natt");
        }
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
        {
            Console.WriteLine($" #{b.Id} {b.Guest.Name}, rum {b.Room.RoomNumber}, " +
                              $"{b.CheckIn:yyyy-MM-dd} till {b.CheckOut:yyyy-MM-dd}, {b.TotalPrice():N0} kr");
        }
    }
    
    private void CancelBooking()
    {
        ShowBookings();
        Console.Write("Bokningsnummer att avboka: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Skriv ett nummer.");
            return;
        }

        bool cancelled = _repository.CancelBooking(id);
        Console.WriteLine(cancelled ? "Bokningen är avbokad." : "Hittade ingen bokning med det numret.");
    }

    private void BookRoom()
    {
        Console.WriteLine("Kommer snart!");
    }
}