using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PostLandInfrastructure.Seed
{
    public static class SeedDataLoader
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var jsonPath = @"D:\PostLand\PostLandAPI\Seed\SeedData.json";

            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                var seedData = JsonConvert.DeserializeObject<SeedData>(json);
                // Seed Categories
                modelBuilder.Entity<Category>().HasData(seedData.Categories);

                // Seed Posts
                modelBuilder.Entity<Post>().HasData(seedData.Posts);
            }
            else
            {
                Console.WriteLine($"File not found: {jsonPath}");
            }


            

            
        }
    }
}
