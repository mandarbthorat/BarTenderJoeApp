using BarTenderJoe.Application.DTOs;
using BarTenderJoe.Application.Interfaces;
using BarTenderJoe.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Application.Commands
{
    public class MixDrinkHandler
    {
        private readonly IProductRepository _repo;
        private readonly IEnumerable<IDrinkMixerStrategy> _strategies;
        public MixDrinkHandler(IProductRepository repo, IEnumerable<IDrinkMixerStrategy> strategies)
        { _repo = repo; _strategies = strategies; }

        public DrinkResultDto? Handle(MixDrinkCommand cmd)
        {
            var product = _repo.GetById(cmd.ProductId);
            if (product == null)
            {
                return new DrinkResultDto
                {
                    ProductId = cmd.ProductId,
                    ProductName = "INVALID PROD TP",
                    Message = "Invalid product for mixing"
                };
            }
            var strategy = _strategies.First(s => s.GetType().Name.StartsWith(product.Name));
            if (strategy == null)
            {
                return new DrinkResultDto
                {
                    ProductId = product.Id,
                    ProductName = product.Name.ToUpper(),
                    Message = "No mixing strategy found for this product"
                };
            }
            var message = strategy.Mix(product);

            return new DrinkResultDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Message = message
            };
        }
    }
}
