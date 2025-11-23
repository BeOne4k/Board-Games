using Board_Games.DTO_s.GamesDto;


namespace Board_Games.Services.Games_Service
{
    public interface IGameService
    {
        Task<IReadOnlyList<GamesResponseDto>> GetAllAsync();
        Task<GamesResponseDto?> GetByIdAsync(int id);
        Task<GamesResponseDto> CreateAsync(GamesCreateDto dto);
        Task<GamesResponseDto?> UpdateAsync(int id, GamesUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
