using Microsoft.EntityFrameworkCore;

namespace DemoCodeFirstApproach.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();//only this line is responsible for code first approach.
        }
        public DbSet<Todo> Todoes { get; set; }
    }
}
