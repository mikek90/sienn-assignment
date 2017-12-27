using System;
using System.Collections.Generic;

namespace SIENN.DbAccess.DTOs
{
    public partial class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
