using Microsoft.EntityFrameworkCore;
using World_Project_First_Web_API.Models;

namespace World_Project_First_Web_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Country> Countries { get; set; }
    }
}
