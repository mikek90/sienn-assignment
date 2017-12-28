﻿using System;

namespace SIENN.BusinessInterfaces
{
    public partial class ProductCategoryDTO
    {
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
