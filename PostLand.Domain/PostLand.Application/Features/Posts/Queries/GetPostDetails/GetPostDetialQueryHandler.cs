using AutoMapper;
using MediatR;
using PostLandApplication.Interfaces;

namespace PostLandApplication.Features.Posts.Queries.GetPostDetails
{
    public class GetPostDetialQueryHandler : IRequestHandler<GetPostDetailsQuery, GetPostDetialViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetialQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository=postRepository;
            _mapper=mapper;
        }

        public async Task<GetPostDetialViewModel> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            var post = _postRepository.GetPostByIdAsync(request.PostId, true);
            return _mapper.Map<GetPostDetialViewModel>(post);
        }
    }
}
