using Microsoft.EntityFrameworkCore;
using justine_webapp.Models;
namespace justine_webapp.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
        public DbSet<item> items { get; set; }
        public DbSet<Type> types {get; set;}
         public DbSet<Instrument> instrument {get; set;}
    }
}