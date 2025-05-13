using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserRepository(PostgreSqlContext context) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> InsertAsync(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User> DeleteAsync(Guid id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user;
        }
    }
}
