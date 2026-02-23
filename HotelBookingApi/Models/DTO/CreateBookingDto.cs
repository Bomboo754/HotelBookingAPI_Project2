namespace HotelBookingApi.Models.DTO;

public class CreateBookingDto
{
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
}