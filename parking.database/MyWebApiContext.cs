using Microsoft.EntityFrameworkCore;

namespace parking.database.Models
{
    public class MyWebApiContext: DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) { }

        public DbSet<Parking> Parking { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<Subcomments> Subcommnets { get; set; }
        public DbSet<Year> Year { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<Day> Day { get; set; }
        public DbSet<User> User { get; set; }
    }
}
