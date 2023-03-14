using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Product
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword;
#nullable enable
        public string? Category { get; set; }
    }
}
