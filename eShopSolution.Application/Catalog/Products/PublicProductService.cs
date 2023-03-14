using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using eShopSolution.ViewModels.Catalog.Product;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDbContext _context;
        public PublicProductService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByKeyword(GetProductPagingRequest request)
        {
            // 1. Select 
            var query = from p in _context.Products
                        select new { p };

            // 2. Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => !x.p.Category.Contains(request.Category));
            }

            // 3. Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.ProductID,
                    Name = x.p.ProductName,
                    Price = x.p.Price,
                    DateCreated = x.p.CreatedDate,
                    Stock = x.p.StockQuantity
                }).ToListAsync();

            //select
            var pagedResult = new PagedResult<ProductViewModel>();
            pagedResult.TotalRecord = totalRow;
            pagedResult.Items = data;

            return pagedResult;
        }
    }
}
