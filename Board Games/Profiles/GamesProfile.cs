using AutoMapper;
using Board_Games.DTO_s.GamesDto;
using Board_Games.DTO_s.UsersDto;
using Board_Games.Entities;

namespace Board_Games.Profiles
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<GamesCreateDto, BoardGames>();
            CreateMap<GamesUpdateDto, BoardGames>();
            CreateMap<BoardGames, GamesResponseDto>();
        }
    }
}
