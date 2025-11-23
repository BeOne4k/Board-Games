using AutoMapper;
using Board_Games.DTO_s.GamesDto;
using Board_Games.DTO_s.UsersDto;
using Board_Games.Entities;
using Board_Games.Repos;
using Microsoft.EntityFrameworkCore;

namespace Board_Games.Services.Games_Service
{
    public class GameService : IGameService
    {
        private readonly IEfRepository<BoardGames> _gamesRepository;
        private readonly IMapper _mapper;
        public GameService(IEfRepository<BoardGames> gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }


        public async Task<GamesResponseDto> CreateAsync(GamesCreateDto dto)
        {
            var games = _mapper.Map<BoardGames>(dto);

            await _gamesRepository.AddAsync(games);
            await _gamesRepository.SaveChangesAsync();
            return _mapper.Map<GamesResponseDto>(games);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var games = await _gamesRepository.GetByIdAsync(id);
            if (games == null)
                return false;
            _gamesRepository.DeleteAsync(games);
            await _gamesRepository.SaveChangesAsync();
            return true;
        }



        public async Task<IReadOnlyList<GamesResponseDto>> GetAllAsync()
        {
            var games = await _gamesRepository.GetAllAsync();
            return _mapper.Map<List<GamesResponseDto>>(games);
        }

        public async Task<GamesResponseDto?> GetByIdAsync(int id)
        {
            var games = await _gamesRepository.GetByIdAsync(id);
            if (games == null)
                return null;

            return _mapper.Map<GamesResponseDto>(games);
        }

        public async Task<GamesResponseDto?> UpdateAsync(int id, GamesUpdateDto dto)
        {
            var games = await _gamesRepository.GetByIdAsync(id);
            if (games == null)
                return null;
            _mapper.Map(dto, games);
            _gamesRepository.UpdateAsync(games);
            await _gamesRepository.SaveChangesAsync();

            return _mapper.Map<GamesResponseDto>(games);
        }

    }
}
