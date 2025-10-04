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
        public static UserDto mapToDto(this User user)
        {
            UserDto dto = new UserDto();
            dto.Id = user.Id;
            return dto;
        }

        public static UserSummaryDto mapToSummaryDto(this User user)
        {
            UserSummaryDto dtoSummary = new UserSummaryDto();
            dtoSummary.Id = user.Id;
            return dtoSummary;
        }
    }
}
