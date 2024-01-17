using AutoMapper;
using MediatR;
using PostLand.Domain;
using PostLandApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandApplication.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IGRepository<Post> _postReposirtory;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IGRepository<Post> postReposirtory, IMapper mapper)
        {
            _postReposirtory=postReposirtory;
            _mapper=mapper;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);
            await _postReposirtory.Update(post);
            return;
        }
    }
}
