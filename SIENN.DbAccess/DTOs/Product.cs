using System;
using System.Collections.Generic;

namespace SIENN.DbAccess.DTOs
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? TypeId { get; set; }
        public int? UnitId { get; set; }

        public Type Type { get; set; }
        public Unit Unit { get; set; }
    }
}
