using BarTenderJoe.Application.DTOs;
using BarTenderJoe.Application.Interfaces;
using BarTenderJoe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Application.Queries
{
    public class GetProductHandler 
    {
        private readonly IProductRepository _repo;
        public GetProductHandler(IProductRepository repo) { _repo = repo; }
        public ProductDto? Handle(GetProductQuery query)
        {
            var product = _repo.GetById(query.ProductId);
            if (product == null) return new ProductDto { Id =0 , Name = "" }; ;

            return new ProductDto { Id = product.Id, Name = product.Name};
        }
    }
}
