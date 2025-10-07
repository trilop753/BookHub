using Business.DTOs.BookDTOs;
using Business.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
