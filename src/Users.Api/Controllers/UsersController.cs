using Asp.Versioning;
using Domain.Entities;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace ArquiteturaHexagonal.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();

            if (users is null || !users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            await userService.AddNewUserAsync(user);
            return Ok(user);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await userService.UpdateUserAsync(user);

            return Ok(user);
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await userService.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
