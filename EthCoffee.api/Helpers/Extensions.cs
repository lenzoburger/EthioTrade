using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EthCoffee.api.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age;
        }

        public static void AddPagination(this HttpResponse response, int pageNumber, int pageSize, int totalPages, int totalItems)
        {
            var paginationHeader = new PaginationHeader(pageNumber, pageSize, totalPages, totalItems);
            var camelCaseFormatting = new JsonSerializerSettings();
            camelCaseFormatting.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatting));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}