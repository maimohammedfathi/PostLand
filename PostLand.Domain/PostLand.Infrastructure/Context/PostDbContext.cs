using Microsoft.EntityFrameworkCore;
using PostLand.Domain;

namespace PostLandInfrastructure.Context
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) 
        { }

        public DbSet<Post> Posts { get; set; }
    }

    
}
