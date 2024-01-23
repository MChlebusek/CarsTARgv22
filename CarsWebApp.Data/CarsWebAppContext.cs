using Microsoft.EntityFrameworkCore;
using CarsWebApp.Core.Domain; // linked core domain with data


namespace CarsWebApp.Data
{
    
    public class CarsWebAppContext : DbContext
    {
        public CarsWebAppContext(DbContextOptions<CarsWebAppContext> options)
           : base(options) { }
        public DbSet<Car> Cars { get; set; }

    }
}
