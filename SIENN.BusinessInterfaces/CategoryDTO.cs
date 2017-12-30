using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class CategoryDTO
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public IEnumerable<ProductCategoryDTO> ProductCategories { get; set; } //= new List<ProductCategoryDTO>();
    }
}
