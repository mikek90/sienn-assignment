using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIENN.WebApi.Models
{
    public class BaseModel
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
