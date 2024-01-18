using PostLand.Domain;

namespace PostLandApplication.Interfaces
{
    public interface IPostRepository : IGRepository<Post>
    {
        Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory);
        Task<Post> GetPostByIdAsync(Guid id, bool includeCategory);
    }
}
