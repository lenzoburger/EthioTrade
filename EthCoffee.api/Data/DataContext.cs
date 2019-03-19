using EthCoffee.api.Models;
using Microsoft.EntityFrameworkCore;

namespace EthCoffee.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
                   
        public DbSet<Value> Values { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}