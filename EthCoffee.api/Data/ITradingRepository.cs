using System.Collections.Generic;
using System.Threading.Tasks;
using EthCoffee.api.Helpers;
using EthCoffee.api.Models;

namespace EthCoffee.api.Data
{
    public interface ITradingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Listing>> GetUserListings(int id);
        Task<IEnumerable<Listing>> GetWatching(int id);
        Task<IEnumerable<int>> GetWatchingIds(int id);
        Task<IEnumerable<User>> GetWatchers(int listingId);
        Task<User> GetUser(int id);
        Task<User> GetUserDetails(int id);
        Task<Listing> GetListing(int id);
        Task<PagedList<Listing>> GetListings(PaginationParams paginationParams, FilterParams filterParams, int userId);
        Task<ListingPhoto> GetListingPhoto(int id);
        Task<ListingPhoto> GetMainListingPhoto(int listingId);
        Task<Avatar> GetAvatar(int id);
        Task<ListingWatch> GetListingWatch(int userId, int listingId);
        Task<Message> GetMessage(int id);
        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
        Task<bool> SaveAll();
    }
}