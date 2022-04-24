using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class OrderWithCustomerDto
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}
