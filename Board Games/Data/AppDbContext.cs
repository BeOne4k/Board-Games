using Board_Games.Entities;
using Microsoft.EntityFrameworkCore;


namespace Board_Games.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<User> Users { get; set; }
    }
}
