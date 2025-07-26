using BarTenderJoe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Domain.Services
{
    public interface IDrinkMixerStrategy
    {
        string Mix(Product product);
    }
}
