using AutoMapper;
using MediatR;
using PostLand.Domain;
using PostLandApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandApplication.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepositry;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepositry, IMapper mapper)
        {
            _postRepositry=postRepositry;
            _mapper=mapper;
        }
        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);
            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if(result.Errors.Any())
            {
                throw new Exception("Post in not valid");
            }

            post = await _postRepositry.Add(post);
            return post.Id;
        }
    }
}
