using AutoMapper;
using MediatR;
using PostLandApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var post = _postRepository.GetPostById(request.PostId, true);
            return _mapper.Map<GetPostDetialViewModel>(post);
        }
    }
}
