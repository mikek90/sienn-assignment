using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.BusinessInterfaces
{
    public class ProductSearchCriteria
    {
        public static ProductSearchCriteria Empty { get { return new ProductSearchCriteria(); } }

        public bool? IsAvailable { get; set; }
        public int[] TypeIds { get; set; }
        public int[] CategoryIds { get; set; }
        public int[] UnitIds { get; set; }

        public int PageNumber { get; set; } = 1;
        public int ItemsCount { get; set; } = 5;
    }
}
