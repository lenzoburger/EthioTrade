using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EthCoffee.api.Helpers
{
    public class PaginationHeader
    {

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        
        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public PaginationHeader(int currentPage, int itemsPerPage, int totalPages, int totalItems)
        {
            PageNumber = currentPage;
            PageSize = itemsPerPage;
            TotalPages = totalPages;
            TotalItems = totalItems;
        }
    }
}