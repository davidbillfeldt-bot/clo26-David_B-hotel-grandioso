using HotelGrandioso.Data;
using HotelGrandioso.Services;
using HotelGrandioso.UI;
using Microsoft.EntityFrameworkCore;

using var context = new HotelContext();
context.Database.Migrate();

var repository = new HotelRepository(context);
var menu = new ConsoleMenu(repository);
menu.Run();