using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelBookingApi.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

     
        var connectionString = "Data Source=hotel.db";  
       
        optionsBuilder.UseSqlite(connectionString); 

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}