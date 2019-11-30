using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EthCoffee.api.Data.seed.Dtos;
using EthCoffee.api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EthCoffee.api.Data
{
    public class Seed
    {

        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText($"Data/seed/{nameof(UserSeedDto)}Data.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordSalt = passwordSalt;
                    user.PasswordHash = passwordHash;
                    user.Username = user.Username.ToLower();

                    context.Add(user);
                }

                context.SaveChanges();
            }
        }

        public static void UpdateSeedDataSource(DataContext context)
        {
            if (context.Users.Any())
            {
                var users = context.Users
                .Include(usr => usr.Avatar)
                .Include(usr => usr.UserAddresses)
                .ThenInclude(usrAdr => usrAdr.Address)
                .Include(usr => usr.UserAddresses)
                .ThenInclude(usrAdrT => usrAdrT.AddressType)
                .Include(usr => usr.MessageSent)
                .Include(usr => usr.MessageReceived)
                .Include(usr => usr.MyListings)
                .ThenInclude(usrAdrT => usrAdrT.Photos)
                .Include(usr => usr.MyListings)
                .ThenInclude(usrAdrT => usrAdrT.Watchers).ToList();                

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserSeedDto>();
                    cfg.CreateMap<Avatar, AvatarSeedDto>();
                    cfg.CreateMap<ListingPhoto, ListingPhotoSeedDto>();
                    cfg.CreateMap<Listing, ListingSeedDto>();
                    cfg.CreateMap<ListingWatch, ListingWatchSeedDto>();
                    cfg.CreateMap<Message, MessageSeedDto>();
                    cfg.CreateMap<UserAddress, UserAddressSeedDto>();
                });

                IMapper iMapper = config.CreateMapper();

                var usersSeed = iMapper.Map<List<UserSeedDto>>(users);

                var usersSeedData = JsonConvert.SerializeObject(usersSeed, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

                System.IO.File.WriteAllText($"Data/seed/{nameof(UserSeedDto)}Data.json", usersSeedData);

            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}