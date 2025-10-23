using BL.DTOs.UserDTOs;
using DAL.Models;

namespace BL.Mappers
{
    public static class UserMapper
    {
        public static UserDto MapToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsBanned = user.IsBanned,
            };
        }

        public static UserSummaryDto MapToSummaryDto(this User user)
        {
            return new UserSummaryDto { Id = user.Id, Username = user.Username };
        }
    }
}
