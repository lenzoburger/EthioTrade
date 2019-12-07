using System;
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

        public static void SeedTableData(DataContext context)
        {
            SeedUserTable(context);

            if (!context.Messages.Any())
            {
                var messageData = System.IO.File.ReadAllText($"Data/seed/{nameof(MessageSeedDto)}Data.json");
                var messages = JsonConvert.DeserializeObject<List<Message>>(messageData);

                foreach (var message in messages)
                {
                    context.Add(message);
                }

                context.SaveChanges();
            }

            if (!context.ListingWatchs.Any())
            {
                var listingWatchsData = System.IO.File.ReadAllText($"Data/seed/{nameof(ListingWatchSeedDto)}Data.json");
                var listingWatchs = JsonConvert.DeserializeObject<List<ListingWatch>>(listingWatchsData);

                foreach (var listingWatch in listingWatchs)
                {
                    context.Add(listingWatch);
                }

                context.SaveChanges();
            }
        }

        public static void SeedUserTable(DataContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

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

            // Uncomment for Sql server
            if (context.Database.IsSqlServer())
            {
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    context.Database.CloseConnection();
                }
            }
            else
            {
                context.SaveChanges();
            }

        }

        public static void UpdateSeedDataSources(DataContext context)
        {
            var iMapper = getSeedImapperConfig().CreateMapper();

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            UpdateUsersDataSource(context, iMapper, jsonSettings);
            UpdateMessagesDataSource(context, iMapper, jsonSettings);
            UpdateListWatchingsDataSource(context, iMapper, jsonSettings);
        }

        public static void UpdateMessagesDataSource(DataContext context, IMapper mapper, JsonSerializerSettings jsonSettings)
        {
            if (!context.Messages.Any())
            {
                return;
            }

            var messages = context.Messages.ToList();
            var messagesSeed = mapper.Map<List<MessageSeedDto>>(messages);
            var messagesSeedData = JsonConvert.SerializeObject(messagesSeed, jsonSettings);

            System.IO.File.WriteAllText($"Data/seed/{nameof(MessageSeedDto)}Data.json", messagesSeedData);
        }

        public static void UpdateListWatchingsDataSource(DataContext context, IMapper mapper, JsonSerializerSettings jsonSettings)
        {
            if (!context.ListingWatchs.Any())
            {
                return;
            }

            var listingWatchs = context.ListingWatchs.ToList();
            var listingWatchsSeed = mapper.Map<List<ListingWatchSeedDto>>(listingWatchs);
            var listingWatchsSeedData = JsonConvert.SerializeObject(listingWatchsSeed, jsonSettings);

            System.IO.File.WriteAllText($"Data/seed/{nameof(ListingWatchSeedDto)}Data.json", listingWatchsSeedData);
        }

        public static void UpdateUsersDataSource(DataContext context, IMapper mapper, JsonSerializerSettings jsonSettings)
        {
            if (!context.Users.Any())
            {
                return;
            }

            var users = context.Users.ToList();

            var usersSeed = mapper.Map<List<UserSeedDto>>(users);
            var usersSeedData = JsonConvert.SerializeObject(usersSeed, jsonSettings);

            System.IO.File.WriteAllText($"Data/seed/{nameof(UserSeedDto)}Data.json", usersSeedData);
        }

        public static MapperConfiguration getSeedImapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserSeedDto>();
                    cfg.CreateMap<Avatar, AvatarSeedDto>();
                    cfg.CreateMap<ListingPhoto, ListingPhotoSeedDto>();
                    cfg.CreateMap<Listing, ListingSeedDto>();
                    cfg.CreateMap<ListingWatch, ListingWatchSeedDto>();
                    cfg.CreateMap<Message, MessageSeedDto>();
                    cfg.CreateMap<UserAddress, UserAddressSeedDto>();
                    cfg.CreateMap<Address, AddressSeedDto>();
                });

            return config;
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