using System.Collections.Generic;
using System.Threading.Tasks;
using EthCoffee.api.Helpers;
using EthCoffee.api.Models;

namespace EthCoffee.api.Data
{
    public interface ITradingRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T:class;         
         Task<User> GetUserListings(int id);
         Task<User> GetUserDetails(int id);
         Task<Listing> GetListing(int id);
         Task<PagedList<Listing>> GetListings(PaginationParams paginationParams, FilterParams filterParams, int userId);
         Task<ListingPhoto> GetListingPhoto(int id);
         Task<ListingPhoto> GetMainListingPhoto(int listingId);
         Task<Avatar> GetAvatar(int id);
         Task<bool> SaveAll();
    }
}