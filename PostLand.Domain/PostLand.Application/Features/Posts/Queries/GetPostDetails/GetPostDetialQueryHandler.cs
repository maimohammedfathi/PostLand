using AutoMapper;
using MediatR;
using PostLandApplication.Interfaces;

namespace PostLandApplication.Features.Posts.Queries.GetPostDetails
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailsQuery, GetPostDetialViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetailQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<GetPostDetialViewModel> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            var Post = await _postRepository.GetPostByIdAsync(request.PostId, true);

            return _mapper.Map<GetPostDetialViewModel>(Post);
        }
    }
}
