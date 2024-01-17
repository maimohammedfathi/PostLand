namespace PostLandApplication.Features.Posts.Queries.GetPostList
{
    public class GetPostListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImagUrl { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
