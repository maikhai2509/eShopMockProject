using Microsoft.AspNetCore.Http;

namespace eShopSolution.ViewModels.Catalog.Product
{
    public class ProductCreateRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
