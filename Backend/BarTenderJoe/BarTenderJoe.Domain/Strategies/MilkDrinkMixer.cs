using BarTenderJoe.Domain.Entities;
using BarTenderJoe.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Domain.Strategies
{
    public class MilkDrinkMixer : IDrinkMixerStrategy
    {
        public string Mix(Product product) => "Milkshake is ready!";
    }
}
