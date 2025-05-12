using System.Text.Json;
using Domain.Entities;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace ArquiteturaHexagonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService, ICacheService cacheService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var userBytes = await cacheService.GetByKeyAsync("user_" + id, default);
            if (userBytes?.Length > 0)
            {
                var userCache = JsonSerializer.Deserialize<User>(userBytes);
                return Ok(userCache);
            }
            
            var user = await userService.GetUserAsync(id);
            await cacheService.AddNewAsync("user_" + user.Id, JsonSerializer.Serialize(user), 60);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            await userService.AddNewUserAsync(user);
            await cacheService.AddNewAsync("user_" + user.Id, JsonSerializer.Serialize(user), 60);
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
            return Ok(user);
        }
    }
}
