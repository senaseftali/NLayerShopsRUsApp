using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class CustomerType : BaseEntity
    {
        public string Name { get; set; }
        //public ICollection<Customer> Customers { get; set; }
        public Discount Discount { get; set; }
        //public int CustomerId { get; set; }

        public ICollection<Customer> Customers { get; set; }
        //public CustomerCustomerType CustomerCustomerType { get; set; }
    }
}
