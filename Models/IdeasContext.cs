using Microsoft.EntityFrameworkCore;

namespace CsharpExam.Models
{
    public class BeltContext : DbContext
    {
        public BeltContext(DbContextOptions options) : base(options) {}
        // tables in db
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}