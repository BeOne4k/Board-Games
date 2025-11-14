using Board_Games.DTO_s.UsersDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Board_Games.Repos;
using Board_Games.Entities;

namespace Board_Games.Services.User_Service
{
    public class UserService : IUserService
    {

        public readonly IMapper _mapper;
        public readonly IEfRepository<User> _userRepo;

        public async Task<UserResponceDto> CreateAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);

            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();
            return _mapper.Map<UserResponceDto>(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) 
                return false;
            _userRepo.DeleteAsync(user);
            await _userRepo.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserResponceDto>> GetAllUsers()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<List<UserResponceDto>>(users);
        }

        public async Task<UserResponceDto> GetUserById(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
                return null;

            return _mapper.Map<UserResponceDto>(user);
        }

        public async Task<UserResponceDto> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
                return null;

            _userRepo.UpdateAsync(user);
            await _userRepo.SaveChangesAsync();
            return _mapper.Map<UserResponceDto>(user);
        }
    }
}
