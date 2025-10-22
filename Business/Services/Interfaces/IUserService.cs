using Business.DTOs.UserDTOs;

namespace Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto?> GetUserByIdAsync(int id);

        public Task<UserSummaryDto?> GetUserSummaryByIdAsync(int id);

        public Task<IEnumerable<UserDto>> GetAllUsersAsync();

        // TODO
        //public Task<UserDto> CreateUserAsync(UserDto dto);

        public Task<bool> UpdateUserAsync(UserUpdateDto dto);
        public Task<bool> DeleteUserAsync(int id);
    }
}
