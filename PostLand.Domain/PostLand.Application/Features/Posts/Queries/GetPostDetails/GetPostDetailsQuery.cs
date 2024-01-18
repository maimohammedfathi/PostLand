using MediatR;

namespace PostLandApplication.Features.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQuery : IRequest<GetPostDetialViewModel>
    { 
        public Guid PostId { get; set; }
    }
}
