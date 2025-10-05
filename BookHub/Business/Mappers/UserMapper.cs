using Business.DTOs.UserDTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    //TODO complete
    public static class UserMapper
    {
        public static UserDto MapToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsBanned = user.IsBanned
            };
        }

        public static UserSummaryDto MapToSummaryDto(this User user)
        {
            return new UserSummaryDto
            {
                Id = user.Id,
                Username = user.Username
            };
        }
    }
}
