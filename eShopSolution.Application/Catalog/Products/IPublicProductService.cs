using eShopSolution.Application.Dtos;
using eShopSolution.ViewModels.Catalog.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    // chứa phương thức cho bên ngoài khách hàng đọc
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByKeyword(GetProductPagingRequest request);
    }
}
