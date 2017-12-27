using System;
using System.Collections.Generic;

namespace SIENN.DbAccess.DTOs
{
    public partial class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
