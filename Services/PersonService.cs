using DayMapper_BE.DatabaseConfig;
using DayMapper_BE.Models;

namespace DayMapper_BE.Services
{
    public class PersonService
    {
        DayMapperAppContext DbContext;
        public PersonService(DayMapperAppContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Person> Get()
        {
            return DbContext.People;
        }

        public async Task<Person> GetOne(Guid id)
        {
            Person person = await DbContext.People.FindAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {id} not found.");
            }
            return person;
        }

        public async Task<Person> Save(Person payload)
        {
            DbContext.Add(payload);
            await DbContext.SaveChangesAsync();

            return payload;
        }

        public async Task<Person> Update(Guid id, Person payload)
        {
            Person person = DbContext.People.Find(id);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {id} not found.");
            }

            DbContext.Entry(person).CurrentValues.SetValues(payload);

            await DbContext.SaveChangesAsync();

            return person; //TODO: check if the entity returns 
        }

        public async Task<string> Delete(Guid id)
        {
            Person person = DbContext.People.Find(id);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {id} not found.");
            }

            DbContext.Remove(person);

            await DbContext.SaveChangesAsync();

            return $"Person with Id {id} was deleted.";
        }
    }

    public interface IPersonService
    {
        IEnumerable<Person> Get();

        Task<Person> GetOne(Guid id);

        Task<Person> Save(Person payload);

        Task<Person> Update(Guid id, Person payload);

        Task<string> Delete(Guid id);
    }
}
