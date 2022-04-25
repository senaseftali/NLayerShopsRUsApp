using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class InvoiceDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        //public int ProductId { get; set; }
        //public Product Product { get; set; }
       


    }
}
