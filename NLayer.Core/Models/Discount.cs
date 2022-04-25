using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Discount:BaseEntity
    {
        public string Name { get; set; }
        
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
        public decimal Rate { get; set; }

        public InvoiceDetail InvoiceDetail { get; set; }
    }
}
