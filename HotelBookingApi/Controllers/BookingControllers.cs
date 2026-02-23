using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Models.DTO;
using System.Security.Claims;

namespace HotelBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookingsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyBookings()
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

        var userId = int.Parse(userIdStr);

        var bookings = await _context.Bookings
            .Where(b => b.UserId == userId)
            .Include(b => b.Room)
                .ThenInclude(r => r.RoomType)
            .Include(b => b.Room)
                .ThenInclude(r => r.Hotel)
            .ToListAsync();

        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto dto)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

        var userId = int.Parse(userIdStr);

        var hasOverlap = await _context.Bookings
            .AnyAsync(b => b.RoomId == dto.RoomId &&
                           b.CheckIn < dto.CheckOut &&
                           b.CheckOut > dto.CheckIn);

        if (hasOverlap)
            return BadRequest("Номер уже забронирован на эти даты");

        var booking = new Booking
        {
            UserId = userId,
            RoomId = dto.RoomId,
            CheckIn = dto.CheckIn,
            CheckOut = dto.CheckOut,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMyBookings), new { id = booking.Id }, booking);
    }
}