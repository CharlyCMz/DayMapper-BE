using DayMapper_BE.DatabaseConfig;
using DayMapper_BE.Models;

namespace DayMapper_BE.Services
{
    public class UserService : IUserService
    {
        DayMapperAppContext DbContext;
        public UserService(DayMapperAppContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<User> Get()
        {
            return DbContext.Users;
        }

        public async Task<User> GetOne(Guid id)
        {
            User user = await DbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {id} not found.");
            }
            return user;
        }

        public async Task<User> Save(User payload)
        {
            DbContext.Add(payload);
            await DbContext.SaveChangesAsync();

            return payload;
        }

        public async Task<User> Update(Guid id, User payload)
        {
            User user = DbContext.Users.Find(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {id} not found.");
            }

            DbContext.Entry(user).CurrentValues.SetValues(payload);

            await DbContext.SaveChangesAsync();

            return user;
        }

        public async Task<string> Delete(Guid id)
        {
            User user = DbContext.Users.Find(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Id {id} not found.");
            }

            DbContext.Remove(user);

            await DbContext.SaveChangesAsync();

            return $"User with Id {id} was deleted.";
        }
    }

    public interface IUserService
    {
        IEnumerable<User> Get();

        Task<User> GetOne(Guid id);

        Task<User> Save(User payload);

        Task<User> Update(Guid id, User payload);

        Task<string> Delete(Guid id);
    }
}
