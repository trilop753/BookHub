using Business.DTOs.UserDTOs;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("summary/{id}")]
        public async Task<ActionResult<UserSummaryDto>> GetSummaryById(int id)
        {
            var user = await _userService.GetUserSummaryByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        #endregion

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserUpdateDto update)
        {
            var res = await _userService.UpdateUserAsync(update);

            if (!res)
            {
                return NotFound($"User with ID {update.Id} was not found.");
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _userService.DeleteUserAsync(id);

            if (!res)
            {
                return NotFound($"User with ID {id} was not found.");
            }

            return NoContent();
        }
    }
}
