using System;
using System.Collections.Generic;

namespace SIENN.BusinessInterfaces
{
    public partial class CategoryDTO : BaseDTO
    {
        public IEnumerable<ProductCategoryDTO> ProductCategories { get; set; } //= new List<ProductCategoryDTO>();
    }
}
