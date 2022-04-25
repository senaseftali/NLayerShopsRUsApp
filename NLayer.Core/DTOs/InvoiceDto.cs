using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class InvoiceDto 
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTypeName { get; set; }
        public int CustomerTypeId{ get; set; }
        public DateTime CustomerCreatedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public string DiscountTypeName { get; set; }

        public List<ProductDto> productDtos { get; set; }
    }
}
