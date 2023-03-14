using eShopSolution.Application.Catalog.Products;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.Catalog.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        //Register function
        [HttpPost]
        public async Task<IActionResult> CreatedUser(User user, ProductCreateRequest request)
        {
                var result = await _manageProductService.Create(request);
                if(result == 0)
                {
                    return BadRequest();
                }         
            return Ok();
        }

        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> Update([FromRoute] int productId, ProductUpdateRequest request)
        {
                request.ProductId = productId;
                var result = await _manageProductService.Update(request);
                if(result == 0)
                {
                    return BadRequest();
                }
            return Ok();
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int productId)
        {
            var result = await _manageProductService.Delete(productId);
            if(result == 0)
            {
                return BadRequest();
            }
            return Ok();     
        }
    }
}
