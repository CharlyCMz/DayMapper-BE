using DayMapper_BE.DatabaseConfig;
using DayMapper_BE.Models;

namespace DayMapper_BE.Services
{
    public class AddressService : IAddressService
    {
        DayMapperAppContext DbContext;
        public AddressService(DayMapperAppContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Address> Get()
        {
            return DbContext.Addresses;
        }

        public async Task<Address> GetOne(Guid id)
        {
            Address address = await DbContext.Addresses.FindAsync(id);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with Id {id} not found.");
            }
            return address;
        }

        public async Task<Address> Save(Address payload)
        {
            DbContext.Add(payload);
            await DbContext.SaveChangesAsync();

            return payload; //TODO: check if the entity returns 
        }

        public async Task<Address> Update(Guid id, Address payload)
        {
            Address address = DbContext.Addresses.Find(id);

            if (address == null)
            {
                throw new KeyNotFoundException($"Address with Id {id} not found.");
            }

            DbContext.Entry(address).CurrentValues.SetValues(payload);

            await DbContext.SaveChangesAsync();

            return address; //TODO: check if the entity returns 
        }

        public async Task Delete(Guid id)
        {
            Address address = DbContext.Addresses.Find(id);

            if (address == null)
            {
                throw new KeyNotFoundException($"Address with Id {id} not found.");
            }

            DbContext.Remove(address);

            await DbContext.SaveChangesAsync();
        }
    }

    public interface IAddressService
    {
        IEnumerable<Address> Get();

        Task<Address> GetOne(Guid id);

        Task<Address> Save(Address payload);

        Task<Address> Update(Guid id, Address payload);

        Task Delete(Guid id);
    }
}
