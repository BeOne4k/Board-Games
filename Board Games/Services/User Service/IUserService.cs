using Board_Games.DTO_s.UsersDto;
using Microsoft.EntityFrameworkCore;

namespace Board_Games.Services.User_Service
{
    public interface IUserService
    {
        Task<List<UserResponceDto>> GetAllUsers();
        Task<UserResponceDto> GetUserById(int id);
        Task<UserResponceDto> CreateAsync(UserCreateDto dto);
        Task<UserResponceDto> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
