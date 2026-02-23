namespace HotelBookingApi.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public int Floor { get; set; }
    public string Status { get; set; } = "Available";   // Available, Occupied, Maintenance

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;

    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; } = null!;

    public List<Booking> Bookings { get; set; } = new();
}