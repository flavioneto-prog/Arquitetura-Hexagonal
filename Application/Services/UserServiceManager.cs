using Domain.Entities;
using Domain.Ports;

namespace Application.Services
{
    public class UserServiceManager(IUserRepository userRepository) : IUserService
    {
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            return users;
        }

        public async Task<User> AddNewUserAsync(User user)
        {
            await userRepository.InsertAsync(user);
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

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await userRepository.GetUserAsync(id);
            return user;
        }
    }
}