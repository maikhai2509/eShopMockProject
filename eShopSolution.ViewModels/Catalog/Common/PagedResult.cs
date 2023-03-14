using System.Collections.Generic;

namespace eShopSolution.Application.Dtos
{
    public class PagedResult<T>
    {
        public List<T> Items;
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
    }
}
