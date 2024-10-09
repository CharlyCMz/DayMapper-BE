using DayMapper_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace DayMapper_BE.DatabaseConfig
{
    public class DayMapperAppContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DayMapperAppContext(DbContextOptions<DayMapperAppContext> options) :base(options) { }
    }
}
