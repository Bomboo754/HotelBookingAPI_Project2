namespace HotelBookingApi.Models;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int StarRating { get; set; }         // 1–5
    public string? Phone { get; set; }

    public List<RoomType> RoomTypes { get; set; } = new();
    public List<Room> Rooms { get; set; } = new();      
}