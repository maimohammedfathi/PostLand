﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandApplication.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommand  : IRequest
    {
        public Guid Id { get; set; }
    }
}
