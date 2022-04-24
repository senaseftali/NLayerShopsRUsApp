using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Order : BaseEntity 
    {
        //public int OrderNo { get; set; }
        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
        public Invoice Invoice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public OrderDetail OrderDetail { get; set; }

    }
}
