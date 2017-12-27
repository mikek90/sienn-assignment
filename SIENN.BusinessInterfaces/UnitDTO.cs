using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class UnitDTO
    {
        public UnitDTO()
        {
            Product = new HashSet<ProductDTO>();
        }

        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<ProductDTO> Product { get; set; }
    }
}
