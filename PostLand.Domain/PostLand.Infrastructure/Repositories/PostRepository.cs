using Microsoft.EntityFrameworkCore;
using PostLand.Domain;
using PostLandApplication.Interfaces;
using PostLandInfrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandInfrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext _PostDbContext): base(_PostDbContext) { }
        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> allPosts = new List<Post>();
            allPosts = includeCategory ? await _context.Posts.Include(post => post.Category).ToListAsync() : await _context.Posts.ToListAsync();
            return allPosts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post post = new Post();
            post = includeCategory ? await _context.Posts.Include(post => post.Category).FirstOrDefaultAsync(post => post.Id == id) : await GetByIdAsync(id);
            return post;
        }
    }
}
