using MediatR;
using PostLandApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandApplication.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository=postRepository;
            _unitOfWork=unitOfWork;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _postRepository.GetByIdAsync(request.PostId);
                if (post == null)
                {
                    throw new Exception("The post ID is notValid");
                }
                await _postRepository.DeleteAsync(post);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return;
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;


            }
        }
    }
}
