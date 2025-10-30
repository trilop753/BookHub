using BL.DTOs.UserDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Result<UserDto>> GetUserByIdAsync(int id);

        public Task<Result<UserSummaryDto>> GetUserSummaryByIdAsync(int id);

        public Task<Result<UserCartDto>> GetUserCartByIdAsync(int id);

        public Task<IEnumerable<UserDto>> GetAllUsersAsync();

        public Task<Result> UpdateUserAsync(int id, UserUpdateDto dto);
        public Task<Result> DeleteUserAsync(int id);
    }
}
