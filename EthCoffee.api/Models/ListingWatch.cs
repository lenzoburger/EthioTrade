namespace EthCoffee.api.Models
{
    public class ListingWatch
    {
        public int WatcherId { get; set; }
        public int WatchingId { get; set; }
        public virtual User Watcher { get; set; }
        public virtual Listing Watching { get; set; }
    }
}