using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class UnitDTO : BaseDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; } //= new List<ProductDTO>();
    }
}
