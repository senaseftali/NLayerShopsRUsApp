using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class DiscountDto : BaseDto
    {
        public string CustomerTypeId { get; set; }
        public double Rate { get; set; }

    }
}
