using BigonWebApp.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonWebApp.Infrastructure.Entities
{
    public class Color : BaseEntity
    {
        public string ColorName { get; set; }
        public string HaxCode { get; set; }
    }
}
