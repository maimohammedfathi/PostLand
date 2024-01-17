using PostLand.Domain;

namespace PostLandApplication.Interfaces
{
    public interface IPostRepository : IGRepository<Post>
    {
        Task<IReadOnlyList<Post>> GetAllPost(bool includeCategory);
        Task<Post> GetPostById(Guid id, bool includeCategory);
    }
}
