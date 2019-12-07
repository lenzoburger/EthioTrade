using System;

namespace EthCoffee.api.Data.seed.Dtos
{
    public class ListingPhotoSeedDto
    {
        public string Url { get; set; }
        public string PublicId  { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}