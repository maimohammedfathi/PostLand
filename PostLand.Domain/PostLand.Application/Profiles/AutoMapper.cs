using AutoMapper;
using PostLand.Domain;
using PostLandApplication.Features.Posts.Commands.CreatePost;
using PostLandApplication.Features.Posts.Queries.GetPostDetails;
using PostLandApplication.Features.Posts.Queries.GetPostList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandApplication.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Post, GetPostListViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetialViewModel>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
        }
    }
}
