using BL.DTOs.UserDTOs;
using BL.Mappers;
using BL.Services.Interfaces;
using FluentResults;
using Infrastructure.Repository.Interfaces;

namespace BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return Result.Fail($"User with id {id} does not exist.");
            }

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return Result.Ok();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => u.MapToDto());
        }

        public async Task<Result<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return Result.Fail($"User with id {id} does not exist");
            }
            return Result.Ok(user.MapToDto());
        }

        public async Task<Result<UserSummaryDto>> GetUserSummaryByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return Result.Fail($"User with id {id} does not exist");
            }

            return Result.Ok(user.MapToSummaryDto());
        }

        public async Task<Result> UpdateUserAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return Result.Fail($"User with id {id} does not exist");
            }

            user.Username = dto.Username;
            user.Email = dto.Email;
            user.IsBanned = dto.IsBanned;

            await _userRepository.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
