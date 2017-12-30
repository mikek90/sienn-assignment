using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class TypeDTO : BaseDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; } //= new List<ProductDTO>();
    }
}
