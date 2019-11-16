namespace EthCoffee.api.Helpers
{
    public interface IPaginationParams
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string SortBy { get; set; }
    }
}