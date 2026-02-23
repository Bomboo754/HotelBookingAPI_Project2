using HotelBookingApi.Models;
using BCrypt.Net;

namespace HotelBookingApi.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
    
        if (context.Hotels.Any())
        {
            return;
        }

        // 1. Hotels
        var hotels = new Hotel[]
        {
            new Hotel
            {
                Name = "Grand Riga Hotel",
                City = "Riga",
                Address = "Brīvības iela 52",
                Description = "A luxurious 5-star hotel in the center of Riga",
                StarRating = 5,
                Phone = "+371 67 123 456"
            },
            new Hotel
            {
                Name = "Baltic Sea Resort",
                City = "Jūrmala",
                Address = "Jūras iela 10",
                Description = "A seaside hotel with a private beach",
                StarRating = 4,
                Phone = "+371 67 654 321"
            }
        };

        context.Hotels.AddRange(hotels);
        context.SaveChanges();

        // 2. Types Of Rooms
        var roomTypes = new RoomType[]
        {
            new RoomType
            {
                Name = "Standard",
                Description = "Standart, one bed",
                PricePerNight = 89.99m,
                MaxGuests = 2,
                BedsCount = 1,
                HotelId = hotels[0].Id
            },
            new RoomType
            {
                Name = "Deluxe",
                Description = "Spacious room with sea view",
                PricePerNight = 149.99m,
                MaxGuests = 3,
                BedsCount = 2,
                HotelId = hotels[1].Id
            },
            new RoomType
            {
                Name = "Suite",
                Description = "Suite with living room and jacuzzi",
                PricePerNight = 299.99m,
                MaxGuests = 4,
                BedsCount = 2,
                HotelId = hotels[0].Id
            }
        };

        context.RoomTypes.AddRange(roomTypes);
        context.SaveChanges();

        // 3. Diff rooms
        var rooms = new Room[]
        {
            new Room { RoomNumber = "101", Floor = 1, Status = "Available", HotelId = hotels[0].Id, RoomTypeId = roomTypes[0].Id },
            new Room { RoomNumber = "205", Floor = 2, Status = "Available", HotelId = hotels[0].Id, RoomTypeId = roomTypes[2].Id },
            new Room { RoomNumber = "312", Floor = 3, Status = "Available", HotelId = hotels[1].Id, RoomTypeId = roomTypes[1].Id }
        };

        context.Rooms.AddRange(rooms);
        context.SaveChanges();

        if (!context.Users.Any(u => u.Username == "testuser"))
        {
            var testUser = new User
            {
                Username = "testuser",
                Email = "test@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123"),
                FirstName = "Test",
                LastName = "User",
                Phone = "+37112345678",
                Role = "Guest"
            };

            context.Users.Add(testUser);
            context.SaveChanges();
        }
    }
    
}