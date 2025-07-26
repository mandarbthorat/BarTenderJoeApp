using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarTenderJoe.Domain.Entities;
namespace BarTenderJoe.Application.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int id);
    }
}
