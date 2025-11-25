using BL.DTOs.UserDTOs;
using WebMVC.Models.User;

namespace WebMVC.Mappers
{
    public static class UserMapper
    {
        public static UserUsernameViewModel MapToUsernameView(this UserSummaryDto user)
        {
            return new UserUsernameViewModel() { Id = user.Id, Username = user.Username };
        }
    }
}
