using DayMapper_BE.DatabaseConfig;
using DayMapper_BE.Models;

namespace DayMapper_BE.Services
{
    public class RolService : IRolService
    {
        DayMapperAppContext DbContext;
        public RolService(DayMapperAppContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Rol> Get()
        {
            return DbContext.Roles;
        }

        public async Task<Rol> GetOne(int id)
        {
            Rol roles = await DbContext.Roles.FindAsync(id);
            if (roles == null)
            {
                throw new KeyNotFoundException($"Rol with Id {id} not found.");
            }
            return roles;
        }

        public async Task<Rol> Save(Rol payload)
        {
            DbContext.Add(payload);
            await DbContext.SaveChangesAsync();

            return payload;
        }

        public async Task<Rol> Update(int id, Rol payload)
        {
            Rol rol = DbContext.Roles.Find(id);

            if (rol == null)
            {
                throw new KeyNotFoundException($"Rol with Id {id} not found.");
            }

            DbContext.Entry(rol).CurrentValues.SetValues(payload);

            await DbContext.SaveChangesAsync();

            return rol;  
        }

        public async Task<string> Delete(int id)
        {
            Rol rol = DbContext.Roles.Find(id);

            if (rol == null)
            {
                throw new KeyNotFoundException($"Rol with Id {id} not found.");
            }

            DbContext.Remove(rol);

            await DbContext.SaveChangesAsync();

            return $"Rol with Id {id} was deleted.";
        }

    }

    public interface IRolService
    {
        IEnumerable<Rol> Get();

        Task<Rol> GetOne(int id);

        Task<Rol> Save(Rol payload);

        Task<Rol> Update(int id, Rol payload);

        Task<string> Delete(int id);
    }
}
