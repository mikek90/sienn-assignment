﻿using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class TypeDTO
    {
        public TypeDTO()
        {
            Product = new HashSet<ProductDTO>();
        }

        public int TypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<ProductDTO> Product { get; set; }
    }
}