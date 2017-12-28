using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models
{
    public class BaseProductRequestModel
    {
        public int PageNumber { get; set; }
        public int ItemsCount { get; set; }
    }
}
