using System.Text.Json;
using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class UserServiceManager(IUserRepository userRepository, ICacheService cacheService) : IUserService
    {
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            return users;
        }

        public async Task<User> AddNewUserAsync(User user)
        {
            await userRepository.InsertAsync(user);
            await cacheService.AddNewAsync("user_" + user.Id, JsonSerializer.Serialize(user), 60);
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var userUpdated = await userRepository.UpdateAsync(user);
            return userUpdated;
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            var userDeleted = await userRepository.DeleteAsync(id);
            return userDeleted;
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            var userBytes = await cacheService.GetByKeyAsync("user_" + id, default);
            if (userBytes?.Length > 0)
            {
                var userCache = JsonSerializer.Deserialize<User>(userBytes);
                return userCache;
            }

            var user = await userRepository.GetUserAsync(id);

            if (user is not null)
            {
                await cacheService.AddNewAsync("user_" + user.Id, JsonSerializer.Serialize(user), 60);
            }

            return user;
        }
    }
}