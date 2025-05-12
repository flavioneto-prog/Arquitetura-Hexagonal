using Domain.Entities;

namespace Domain.Ports
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetUserAsync(Guid id);

        Task<User> InsertAsync(User user);

        Task<User> UpdateAsync(User user);

        Task<User> DeleteAsync(Guid id);
    }
}
