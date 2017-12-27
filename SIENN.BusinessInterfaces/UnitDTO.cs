using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class UnitDTO
    {
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; } //= new List<ProductDTO>();
    }
}
