using DayMapper_BE.DatabaseConfig;
using DayMapper_BE.Models;

namespace DayMapper_BE.Services
{
    public class CustomerService : ICustomerService
    {
        DayMapperAppContext DbContext;
        public CustomerService(DayMapperAppContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Customer> Get()
        {
            return DbContext.Customers;
        }

        public async Task<Customer> GetOne(Guid id)
        {
            Customer customer = await DbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with Id {id} not found.");
            }
            return customer;
        }

        public async Task<Customer> Save(Customer payload)
        {
            DbContext.Add(payload);
            await DbContext.SaveChangesAsync();

            return payload; 
        }

        public async Task<Customer> Update(Guid id, Customer payload)
        {
            Customer customer = DbContext.Customers.Find(id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with Id {id} not found.");
            }

            DbContext.Entry(customer).CurrentValues.SetValues(payload);

            await DbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<string> Delete(Guid id)
        {
            Customer customer = DbContext.Customers.Find(id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with Id {id} not found.");
            }

            DbContext.Remove(customer);

            await DbContext.SaveChangesAsync();

            return $"Customer with Id {id} was deleted.";
        }
    }

    public interface ICustomerService
    {
        IEnumerable<Customer> Get();

        Task<Customer> GetOne(Guid id);

        Task<Customer> Save(Customer payload);

        Task<Customer> Update(Guid id, Customer payload);

        Task<string> Delete(Guid id);
    }
}
