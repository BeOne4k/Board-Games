using AutoMapper;
using Board_Games.DTO_s.UsersDto;
using Board_Games.Entities;

namespace Board_Games.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserResponceDto>();
        }
    }
}
