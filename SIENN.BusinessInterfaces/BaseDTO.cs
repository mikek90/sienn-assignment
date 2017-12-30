using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.BusinessInterfaces
{
    public partial class BaseDTO
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
