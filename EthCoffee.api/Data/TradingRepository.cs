using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthCoffee.api.Helpers;
using EthCoffee.api.Models;
using Microsoft.EntityFrameworkCore;

namespace EthCoffee.api.Data
{
    public class TradingRepository : ITradingRepository
    {
        private readonly DataContext _context;

        public TradingRepository(DataContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUserListings(int id)
        {
            var user = await _context.Users
            .Include(usr => usr.Avatar)
            .Include(usr => usr.UserAddresses)
            .ThenInclude(usrAdr => usrAdr.Address)
            .Include(usr => usr.UserAddresses)
            .ThenInclude(usrAdrT => usrAdrT.AddressType)
            .Include(usr => usr.MyListings)
                .ThenInclude(p => p.Photos)
            .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetUserDetails(int id)
        {
            var user = await _context.Users
            .Include(usr => usr.Avatar)
            .Include(usr => usr.UserAddresses)
            .ThenInclude(usrAdr => usrAdr.Address)
            .Include(usr => usr.UserAddresses)
            .ThenInclude(usrAdrT => usrAdrT.AddressType)
            .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<Listing> GetListing(int id)
        {
            var listing = await _context.Listings
            .Include(p => p.Photos)
            .Include(l => l.User)
            .ThenInclude(u => u.Avatar)
            .FirstOrDefaultAsync(l => l.id == id);
            return listing;
        }

        public async Task<PagedList<Listing>> GetListings(int userId, PaginationParams paginationParams, FilterParams filterParams)
        {
            var listings = _context.Listings.Include(p => p.Photos).AsQueryable();
            listings = listings.Where(l => l.Category.ToLowerInvariant().Contains(filterParams.Category.ToLowerInvariant()));
            listings = listings.Where(l => l.Title.ToLowerInvariant().Contains(filterParams.title.ToLowerInvariant()));
            listings = listings.Where(l => l.UserId != userId);

            return await PagedList<Listing>.CreateAsync(listings, paginationParams.PageNumber, paginationParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ListingPhoto> GetListingPhoto(int id)
        {
            var listingPhoto = await _context.ListingPhotos.FirstOrDefaultAsync(lp => lp.Id == id);
            return listingPhoto;
        }

        public async Task<Avatar> GetAvatar(int id)
        {
            var avatar = await _context.Avatars.FirstOrDefaultAsync(a => a.Id == id);
            return avatar;
        }

        public async Task<ListingPhoto> GetMainListingPhoto(int listingId)
        {
            return await _context.ListingPhotos.Where(l => l.ListingId == listingId)
            .FirstOrDefaultAsync(p => p.IsMain);
        }
    }
}