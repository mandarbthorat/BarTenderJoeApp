using BarTenderJoe.Application.DTOs;
using BarTenderJoe.Application.Queries;
using BarTenderJoe.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarTenderJoe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetProductHandler _handler;
        public ProductsController(GetProductHandler handler) { _handler = handler; }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (!int.TryParse(id, out int productId))
            {
                return Ok(new ProductDto { Id = 0, Name = "" });
            }
            var product = _handler.Handle(new GetProductQuery { ProductId = productId });

            if (product == null)
                return Ok(new ProductDto { Id = productId, Name = "" });

            return Ok(new ProductDto { Id = product.Id, Name = product.Name});
        }
    }
}
