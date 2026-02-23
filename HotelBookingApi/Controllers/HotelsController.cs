using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Authorization;
namespace HotelBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class HotelsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public HotelsController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get a list of all hotels
    /// </summary>
    /// <returns>Hotel list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
    {
        return await _context.Hotels
            .Include(h => h.RoomTypes)      
            .ToListAsync();
    }

    /// <summary>
    /// Take hotel by ID
    /// </summary>
    /// <param name="id">Hotel ID</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Hotel>> GetHotel(int id)
    {
        var hotel = await _context.Hotels
            .Include(h => h.RoomTypes)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (hotel == null)
            return NotFound();

        return hotel;
    }
}