using BarTenderJoe.Domain.Entities;
using BarTenderJoe.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Domain.Strategies
{
    public class OrangeDrinkMixer : IDrinkMixerStrategy
    {
        public string Mix(Product product) => "Orange Drink is ready!";
    }
}
