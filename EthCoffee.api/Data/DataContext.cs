using EthCoffee.api.Models;
using Microsoft.EntityFrameworkCore;

namespace EthCoffee.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
                   
        public DbSet<Value> Values { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Avatar> Avatars { get; set; }

        public DbSet<Listing> Listings { get; set; }
        
        public DbSet<ListingPhoto> ListingPhotos { get; set; }
    }
}