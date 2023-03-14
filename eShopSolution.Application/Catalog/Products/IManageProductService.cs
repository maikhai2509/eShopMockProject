using eShopSolution.Application.Dtos;
using eShopSolution.ViewModels.Catalog.Product;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    //thêm sửa xóa sản phẩm bên admin
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId,int addQuantity);
        Task AddViewcount (int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
