using DelsaMovie.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DelsaMovie.Data
{
    public class DatabaseContext :DbContext

    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }  
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Link> Links { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
