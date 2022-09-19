using AutoMapper;
using DelsaMovie.Data.Entities;
using DelsaMovie.Models;

namespace DelsaMovie.Configurations
{
    public class MapperInitializer :Profile
    {
        public MapperInitializer()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Link, LinkDTO>().ReverseMap();
            CreateMap<Link, CreateLinkDTO>().ReverseMap();


        }
    }
}
