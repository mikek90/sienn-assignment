using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models
{
    public class SpecialProductModel
    {
        public string ProductDescription { get; set; }
        public string Price { get; set; }
        public string IsAvailable { get; set; }
        public string DeliveryDate { get; set; }
        public int CategoriesCount { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }
}
