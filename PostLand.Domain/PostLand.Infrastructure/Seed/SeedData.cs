using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandInfrastructure.Seed
{
    public class SeedData
    {
        public List<Category> Categories { get; set; }
        public List<Post> Posts { get; set; }
    }
}
