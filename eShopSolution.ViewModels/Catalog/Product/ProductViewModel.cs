using System;

namespace eShopSolution.ViewModels.Catalog.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public int Stock { get; set; }
    }
}
