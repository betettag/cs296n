using CommunitySite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunitySite.Repositories
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() : base() { }
        public DbSet<Topic> Topics { get; set; }
        //public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Message> Comments { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
