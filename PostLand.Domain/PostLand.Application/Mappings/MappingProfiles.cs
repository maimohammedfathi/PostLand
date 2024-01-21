using AutoMapper;
using PostLand.Domain;
using PostLandApplication.Features.Posts.Commands.CreatePost;
using PostLandApplication.Features.Posts.Commands.DeletePost;
using PostLandApplication.Features.Posts.Commands.UpdatePost;
using PostLandApplication.Features.Posts.Queries.GetPostDetails;
using PostLandApplication.Features.Posts.Queries.GetPostList;
using PostLandApplication.Features.Posts.Queries.GetPostList.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLandApplication.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Post, GetPostListViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetialViewModel>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            //CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();
            CreateMap<CreatePostCommand, Post>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
    .ForMember(dest => dest.Category, opt => opt.Ignore());

        }
    }
}
