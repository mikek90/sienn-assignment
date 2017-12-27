using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class TypeDTO
    {
        public int? TypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; } //= new List<ProductDTO>();
    }
}
