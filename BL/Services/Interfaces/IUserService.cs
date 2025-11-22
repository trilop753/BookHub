using BL.DTOs.UserDTOs;
using FluentResults;

namespace BL.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetUserByIdAsync(int id);
        Task<Result<UserSummaryDto>> GetUserSummaryByIdAsync(int id);
        Task<Result<UserCartDto>> GetUserCartByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<Result> UpdateUserAsync(int id, UserUpdateDto dto);
        Task<Result> DeleteUserAsync(int id);
    }
}
