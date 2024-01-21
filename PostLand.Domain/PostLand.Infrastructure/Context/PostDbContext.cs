using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using PostLand.Domain;
using PostLandInfrastructure.Seed;
using System.Reflection;

namespace PostLandInfrastructure.Context
{
    public class PostDbContext : DbContext
    {
        public PostDbContext() { }
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) 
        { }

        public DbSet<Post> Posts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Post>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.SeedData();
        }

    }   

        //public bool AllMigrationApplied()
        //{
        //    var applied = this.GetService<IHistoryRepository>()
        //        .GetAppliedMigrations()
        //        .Select(m => m.MigrationId);

        //    var total = this.GetService<IMigrationsAssembly>()
        //        .Migrations
        //        .Select(m => m.Key);
        //    return !total.Except(applied).Any();
        //}

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await base.SaveChangesAsync();
        //}

        //public void Migrate()
        //{
        //    Database.Migrate();
        //} 
}
