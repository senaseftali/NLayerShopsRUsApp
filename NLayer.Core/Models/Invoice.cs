using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Invoice : BaseEntity
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
    }
}
