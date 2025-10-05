using Business.DTOs.UserDTOs;
using Business.Mappers;
using Business.Services.Interfaces;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<bool> DeleteUserAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);

			if (user == null) return false;

			_userRepository.Delete(user);
			await _userRepository.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
		{
			var users = await _userRepository.GetAllAsync();

			return users.Select(u => u.MapToDto());
		}

		public async Task<UserDto?> GetUserByIdAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);

			return user?.MapToDto();
		}

		public async Task<UserSummaryDto?> GetUserSummaryByIdAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);

			return user?.MapToSummaryDto();
		}

		public async Task<bool> UpdateUserAsync(UserUpdateDto dto)
		{
			var user = await _userRepository.GetByIdAsync(dto.Id);

			if (user == null) return false;

			user.Username = dto.Username;
			user.Email = dto.Email;
			user.IsBanned = dto.IsBanned;

			await _userRepository.SaveChangesAsync();
			return true;
		}
	}
}
