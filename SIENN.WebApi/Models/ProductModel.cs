using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models
{
    public class ProductModel : BaseModel
    {
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; } = false;
        public DateTime? DeliveryDate { get; set; }

        public int? UnitId { get; set; }
        public int? TypeId { get; set; }
        public int[] CategoryIds { get; set; }
    }
}
