using EthCoffee.api.Models;
using Microsoft.EntityFrameworkCore;

namespace EthCoffee.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingPhoto> ListingPhotos { get; set; }
        public DbSet<ListingWatch> ListingWatchs { get; set; }

        // override the OnModelCreating method - UserAddress
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>().HasKey(ua => new { ua.UserId, ua.AddressId, ua.AddressTypeId });
            modelBuilder.Entity<AddressType>().HasData(
                new AddressType {Id = 1, Type = "Physical"},
                new AddressType {Id = 2, Type = "Shipping"},
                new AddressType {Id = 3, Type = "Billing"},
                new AddressType {Id = 4, Type = "Postal"},
                new AddressType {Id = 5, Type = "Headquarters"});

            modelBuilder.Entity<ListingWatch>()
            .HasKey(k => new { k.WatcherId, k.WatchingId});

            modelBuilder.Entity<ListingWatch>()
            .HasOne(u => u.Watcher)
            .WithMany(u => u.Watchings)
            .HasForeignKey(u => u.WatcherId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ListingWatch>()
            .HasOne(l => l.Watching)
            .WithMany(l => l.Watchers)
            .HasForeignKey(l => l.WatchingId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}