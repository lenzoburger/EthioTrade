namespace EthCoffee.api.Dtos
{
    public class UserDetailsUpdateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }        
        public string Bio { get; set; }
        public string Interests { get; set; }
    }
}