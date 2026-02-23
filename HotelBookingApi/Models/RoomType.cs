namespace HotelBookingApi.Models;

public class RoomType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;     // Standard, Deluxe, Suite...
    public string? Description { get; set; }
    public decimal PricePerNight { get; set; }
    public int MaxGuests { get; set; }
    public int BedsCount { get; set; }

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;

    public List<Room> Rooms { get; set; } = new();
}