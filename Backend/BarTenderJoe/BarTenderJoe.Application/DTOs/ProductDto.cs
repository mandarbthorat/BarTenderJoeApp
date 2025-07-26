using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ProductResponse
        {
            get
            {
                return Id switch
                {
                    1 => "MILK",
                    2 => "ORANGE",
                    _ => "INVALID PROD TP"
                };
            }
        }
        public string ReadyMsg
        {
            get => (ProductResponse == "INVALID PROD TP") ? "CANNOT MIX IT" : "READY TO MIX";
        }
    }
}
