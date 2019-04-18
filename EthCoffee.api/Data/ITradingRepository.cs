using System.Collections.Generic;
using System.Threading.Tasks;
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
         Task<IEnumerable<Listing>> GetListings();
         Task<bool> SaveAll();
    }
}