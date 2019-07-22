using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EthCoffee.api.Helpers
{
    public class PagedList<T> : List<T>
    {

        public int PageNumber { get; set; }

        
        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public PagedList(List<T> items, int pageNumber, int pageSize, int totalItems)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = (int) Math.Ceiling(totalItems/(double)pageSize);
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNum, int pageSize){
            var itemsCount = await source.CountAsync();
            var maxPageNum = (int) Math.Ceiling(itemsCount/(double)pageSize);
            var pageNumber = (pageNum > maxPageNum) ? maxPageNum : pageNum;
                      
            var items = await source.Skip((pageNumber -1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, pageNumber, pageSize, itemsCount);
        }        
    }
}