using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunitySite.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() : base() { }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Comments { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
