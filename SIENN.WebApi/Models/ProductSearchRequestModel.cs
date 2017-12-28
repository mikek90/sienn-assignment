using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models
{
    public class ProductSearchRequestModel : BaseProductRequestModel
    {
        public int[] TypeIds { get; set; }
        public int[] CategoryIds { get; set; }
        public int[] UnitIds { get; set; }
    }
}
