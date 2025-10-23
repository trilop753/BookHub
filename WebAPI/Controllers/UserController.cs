using BL.DTOs.UserDTOs;
using BL.Services.Interfaces;
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
            var result = await _userService.GetUserByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return Ok(result.Value);
        }

        [HttpGet("summary/{id}")]
        public async Task<ActionResult<UserSummaryDto>> GetSummaryById(int id)
        {
            var result = await _userService.GetUserSummaryByIdAsync(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return Ok(result.Value);
        }

        #endregion

        [HttpPut]
        public async Task<ActionResult> Update(int id, [FromBody] UserUpdateDto update)
        {
            var result = await _userService.UpdateUserAsync(id, update);

            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if (result.IsFailed)
            {
                return NotFound(result.Errors);
            }

            return NoContent();
        }
    }
}
