using BarTenderJoe.Domain.Entities;
using BarTenderJoe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new() {
        new Product(1, "Milk"),
        new Product(2, "Orange")
    };

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
