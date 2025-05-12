using Domain.Entities;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace ArquiteturaHexagonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();

            if (!users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

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

        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            await userService.AddNewUserAsync(user);
            return Ok(user);
        }

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
