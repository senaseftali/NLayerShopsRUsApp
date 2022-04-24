﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<CustomerType> CustomerTypes { get; set; }
        //public CustomerCustomerType CustomerCustomerType { get; set; }
        public Invoice Invoice { get; set; }
        public Order Order { get; set; }
    }
}
