using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using eShopSolution.ViewModels.Catalog.Product;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using eShopSolution.Application.Common;
using System.Security.Cryptography.X509Certificates;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ManageProductService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewcount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount = product.ViewCount + 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product();
            product.Price = request.Price;
            product.StockQuantity = request.Stock;
            product.ProductName = request.Name;
            product.ViewCount = 0;
            product.CreatedDate = DateTime.Now;

            //save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.Products.FirstAsync(i => i.ProductID == request.ProductId);
                if (thumbnailImage != null)
                {
                    product.Path_Img = await SaveFile(request.ThumbnailImage);
                    _context.Products.Update(thumbnailImage);
                }
            }

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product: {productId}");
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product: {request.ProductId}");
            }
            product.ProductName = request.ProductName;
            product.Description = request.Description;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.Products.FindAsync(request.ProductId);
                if (thumbnailImage != null)
                {
                    product.Path_Img = await SaveFile(request.ThumbnailImage);
                    _context.Products.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //select 
            var query = from p in _context.Products
                        select new { p };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.ProductName.Contains(request.Keyword));
            }
            // Paging
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

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product with id: {productId}");
            }
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> UpdateStock(int productId, int addQuantity)
        {
            throw new NotImplementedException();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

    }
}
