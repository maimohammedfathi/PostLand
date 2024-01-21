using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandApplication.Features.Posts.Commands.CreatePost
{
    public class CreateCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull();
        }
    }
}
