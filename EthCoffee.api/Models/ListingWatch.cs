namespace EthCoffee.api.Models
{
    public class ListingWatch
    {
        public int WatcherId { get; set; }
        public int WatchingId { get; set; }
        public User Watcher { get; set; }
        public Listing Watching { get; set; }
    }
}